using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Common.Enums;
using Tapar.Core.Common.Services.ImageUploader;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using TaparApi.Data;
using TaparApi.Data.Contracts.Repositories;


namespace Tapar.Core.Contracts.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        #region Properties
        public IImageUploader imageUploader { get; set; }
        public ILuceneSearch Lucene { get; set; }
        public IHttpContextAccessor httpContextAccessor { get; set; }
        public IMapper mapper { get; set; }
        public IRepository<WeekDays> WorkTimeRepository { get; set; }
        #endregion

        #region Constructor
        public PlaceRepository(
         TaparDbContext dbContext,
         IImageUploader imageUploader,
         IHttpContextAccessor httpContextAccessor,
         IMapper mapper,
         IRepository<WeekDays> workTimeRepository
,
         ILuceneSearch lucene) : base(dbContext)
        {
            this.imageUploader = imageUploader;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            WorkTimeRepository = workTimeRepository;
            Lucene = lucene;
        }
        #endregion

        #region General
        public async Task AddPlace(PlaceAddDto dto, CancellationToken cancellationToken)
        {
            Place place = new Place();
            place.tablo = dto.tablo;
            place.service_description = dto.description;
            place.manager = dto.modir;
            place.StatusId = 1;
            place.locationId = int.Parse(dto.address.shahrestan);
            place.address = dto.address.restAddress;
            place.phone1 = dto.relationWays.phone1;
            place.phone2 = dto.relationWays.phone2 != "undefined" ? dto.relationWays.phone2 : null;
            place.phone3 = dto.relationWays.phone3 != "undefined" ? dto.relationWays.phone3 : null;
            place.mob1 = dto.relationWays.mob1;
            place.mob2 = dto.relationWays.mob2 != "undefined" ? dto.relationWays.mob2 : null;
            place.fax = dto.relationWays.fax;
            place.website = dto.relationWays.website;
            place.email = dto.relationWays.email;
            place.telegram = dto.relationWays.telegram;
            place.instagram = dto.relationWays.instagram;
            place.whatsapp = dto.relationWays.whatsapp;
            place.workTimeId = dto.workingTimeId;
            switch (dto.businessPics?.Count)
            {
                case 1:
                    place.bussiness_pic1 = await imageUploader.UploadImage(dto.businessPics[0]);
                    break;
                case 2:
                    place.bussiness_pic1 = await imageUploader.UploadImage(dto.businessPics[0]);
                    place.bussiness_pic2 = await imageUploader.UploadImage(dto.businessPics[1]);
                    break;
                case 3:
                    place.bussiness_pic1 = await imageUploader.UploadImage(dto.businessPics[0]);
                    place.bussiness_pic2 = await imageUploader.UploadImage(dto.businessPics[1]);
                    place.bussiness_pic3 = await imageUploader.UploadImage(dto.businessPics[2]);
                    break;
            }

            if (dto.modirPic?.Length > 0)
                place.personal_pic = await imageUploader.UploadImage(dto.modirPic);
            switch (dto.visitCartPics?.Count)
            {
                case 1:
                    place.visitCart_front = await imageUploader.UploadImage(dto.visitCartPics[0]);
                    break;
                case 2:
                    place.visitCart_front = await imageUploader.UploadImage(dto.visitCartPics[0]);
                    place.visitCart_back = await imageUploader.UploadImage(dto.visitCartPics[1]);
                    break;
            }
            place.userId = long.Parse(httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (place.workTimeId == 3)
            {
                place.weekDay = new WeekDays();
                foreach (var item in dto.workingDays)
                {
                    switch (item.id)
                    {
                        case 1:
                            if (item.am && !item.pm)
                                place.weekDay!.saturday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.saturday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.saturday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.saturday = (int)WeekDaysEnum.NoTime;
                            break;
                        case 2:
                            if (item.am && !item.pm)
                                place.weekDay!.sunday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.sunday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.sunday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.sunday = (int)WeekDaysEnum.NoTime;
                            break;
                        case 3:
                            if (item.am && !item.pm)
                                place.weekDay!.monday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.monday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.monday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.monday = (int)WeekDaysEnum.NoTime;
                            break;
                        case 4:
                            if (item.am && !item.pm)
                                place.weekDay!.tuesday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.tuesday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.tuesday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.tuesday = (int)WeekDaysEnum.NoTime;
                            break;
                        case 5:
                            if (item.am && !item.pm)
                                place.weekDay!.wednesday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.wednesday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.wednesday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.wednesday = (int)WeekDaysEnum.NoTime;
                            break;
                        case 6:
                            if (item.am && !item.pm)
                                place.weekDay!.thursday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.thursday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.thursday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.thursday = (int)WeekDaysEnum.NoTime;
                            break;
                        case 7:
                            if (item.am && !item.pm)
                                place.weekDay!.friday = (int)WeekDaysEnum.Morning;
                            if (!item.am && item.pm)
                                place.weekDay!.friday = (int)WeekDaysEnum.Evening;
                            if (item.am && item.pm)
                                place.weekDay!.friday = (int)WeekDaysEnum.Morning_Evening;
                            if (!item.am && !item.pm)
                                place.weekDay!.friday = (int)WeekDaysEnum.NoTime;
                            break;
                    }
                }
            }
            place.cDate = DateTime.Now;
            await AddAsync(place, cancellationToken);
            Lucene.AddDocumentToLucene(place);
        }
        public async Task<List<Place>> SearchPlace(SearchParams searchParams, CancellationToken cancellationToken)
        {
            IQueryable<Place> query = TableNoTracking.Include(p => p.weekDay).
            AsSplitQuery().AsQueryable();

            if (searchParams.searchKey != null)
            {
                query = query.Where(p => p.tablo.Contains(searchParams.searchKey));
            }
            if (searchParams.cityId > 0)
            {
                query = query.Where(p => p.locationId.ToString() == searchParams.cityId.ToString());
            }

            query = query.Skip((searchParams.pageIndex - 1) * 5).Take(5);
            return await query.ToListAsync(cancellationToken);
        }
        public async Task<int?> AddLikeForPlace(long idplaceId, CancellationToken cancellationToken)
        {
            var userid = long.Parse(httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var place = await Table.Include(p => p.likeCounts).SingleOrDefaultAsync(p => p.Id == idplaceId);
            if (!place.likeCounts.Any(p => p.userId == userid))
            {
                place.likeCounts.Add(new LikeCount()
                {
                    likeDate = new DateTime(),
                    placeId = idplaceId,
                    userId = userid
                });
                place.like_count = place.likeCounts.Count();
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);
                return place.like_count;
            }
            return -1;
        }
        public async Task AddView(long placeId, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, placeId);
            place.view_count += 1;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }
        #endregion

        #region UserPanel
        public async Task<List<Place>> GetPlacesByUserId(SearchParamsForUserPanel dto, CancellationToken cancellationToken)
        {
            var places = TableNoTracking.Where(p => p.userId == dto.userid);
            if (dto.searchKey != null)
                places = places.Where(p => p.tablo.Contains(dto.searchKey));
            places = places.Skip((dto.pageIndex - 1) * 5).Take(5);

            return await places.ToListAsync(cancellationToken);
        }

        public async Task<GetPlaceForEditAddressDto> GetPlaceForEditAddress(long placeId, CancellationToken cancellationToken)
        {
            var place = await TableNoTracking.Include(p => p.location).SingleOrDefaultAsync(p => p.Id == placeId);
            var childLocationId = place.locationId;
            var parentLocationId = place.location.parentId;
            var restAddress = place.address;
            var data = new GetPlaceForEditAddressDto() { ChildLocationId = childLocationId, ParentLocationId = (int)parentLocationId!, RestAddress = restAddress };
            return data;
        }

        public async Task UpdatePlacePics(PlacePicUpdateDto dto, Place place, CancellationToken cancellationToken)
        {

            if (dto.businessPic1?.Length > 0)
            {
                place.bussiness_pic1 = await imageUploader.UpdateImage(dto.businessPic1, place?.bussiness_pic1);
            }
            if (dto.businessPic2?.Length > 0)
            {
                place.bussiness_pic2 = await imageUploader.UpdateImage(dto.businessPic2, place?.bussiness_pic2);
            }
            if (dto.businessPic3?.Length > 0)
            {
                place.bussiness_pic3 = await imageUploader.UpdateImage(dto.businessPic3, place?.bussiness_pic3);
            }
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task UpdateModirPic(UpdateModiPicDto dto, Place place, CancellationToken cancellationToken)
        {
            if (dto?.modirpic?.Length > 0)
            {
                place.personal_pic = await imageUploader.UpdateImage(dto.modirpic, place?.personal_pic);
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);
            }
        }

        public async Task UpdateVisitCartPic(UpdateVisitCartPic dto, Place place, CancellationToken cancellationToken)
        {
            if (dto.visitcart_front?.Length > 0)
            {
                place.visitCart_front = await imageUploader.UpdateImage(dto.visitcart_front, place?.visitCart_front);
            }
            if (dto.visitcart_back?.Length > 0)
            {
                place.visitCart_back = await imageUploader.UpdateImage(dto.visitcart_back, place?.visitCart_back);
            }

            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task UpdateWorkTime(UpdateWorkTimeDto dto, CancellationToken cancellationToken)
        {
            var place = await Table.Include(p => p.weekDay).SingleOrDefaultAsync(p => p.Id == dto.PlaceId);
            place.workTimeId = dto.WorkTimeId;
            if (place.workTimeId == 1 || place.workTimeId == 2)
            {
                var weekday = await WorkTimeRepository.Table.SingleOrDefaultAsync(p => p.placeId == place.Id);
                if (weekday != null) { await WorkTimeRepository.DeleteAsync(weekday, cancellationToken); }
            }
            if (place.workTimeId == 3)
            {
                if (place.weekDay != null)
                {
                    foreach (var item in dto.WorkingDays)
                    {
                        switch (item.id)
                        {
                            case 1:
                                if (item.am && !item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 2:
                                if (item.am && !item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 3:
                                if (item.am && !item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 4:
                                if (item.am && !item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 5:
                                if (item.am && !item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 6:
                                if (item.am && !item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 7:
                                if (item.am && !item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.NoTime;
                                break;
                        }
                    }
                }

                else
                {
                    place.weekDay = new WeekDays();
                    foreach (var item in dto.WorkingDays)
                    {
                        switch (item.id)
                        {
                            case 1:
                                if (item.am && !item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.saturday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 2:
                                if (item.am && !item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.sunday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 3:
                                if (item.am && !item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.monday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 4:
                                if (item.am && !item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.tuesday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 5:
                                if (item.am && !item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.wednesday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 6:
                                if (item.am && !item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.thursday = (int)WeekDaysEnum.NoTime;
                                break;
                            case 7:
                                if (item.am && !item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.Morning;
                                if (!item.am && item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.Evening;
                                if (item.am && item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.Morning_Evening;
                                if (!item.am && !item.pm)
                                    place.weekDay!.friday = (int)WeekDaysEnum.NoTime;
                                break;
                        }
                    }
                }

            }
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task UpdateGlobalInformation(EditGlobalInformationDto dto, CancellationToken cancellationToken)
        {
            var place = await Table.SingleOrDefaultAsync(p => p.Id == dto.id, cancellationToken);
            place.tablo = dto.tablo;
            place.manager = dto.manager;
            place.service_description = dto.service_description;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task DeleteBusiness(long id, CancellationToken cancellationToken)
        {
            var place = await Table.Include(p => p.weekDay).SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (place?.weekDay is not null)
                await WorkTimeRepository.DeleteAsync(place.weekDay, cancellationToken);
            if (place?.bussiness_pic1 is not null)
                await imageUploader.DeleteImage(place.bussiness_pic1);
            if (place?.bussiness_pic2 is not null)
                await imageUploader.DeleteImage(place.bussiness_pic2);
            if (place?.bussiness_pic3 is not null)
                await imageUploader.DeleteImage(place.bussiness_pic3);
            if (place?.personal_pic is not null)
                await imageUploader.DeleteImage(place.personal_pic);
            if (place?.visitCart_front is not null)
                await imageUploader.DeleteImage(place.visitCart_front);
            if (place?.visitCart_back is not null)
                await imageUploader.DeleteImage(place.visitCart_back);
            await DeleteAsync(place, cancellationToken);
            Lucene.DeletePlace(id);
        }

        public async Task<Place> DeleteImage(DeleteImageDto Dto, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, Dto.PlaceId);
            if (Dto.FieldName is "PlacePic1")
            {
                await imageUploader.DeleteImage(Dto.ImageName);
                place.bussiness_pic1 = null;
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);
            }
            if (Dto.FieldName is "PlacePic2")
            {
                await imageUploader.DeleteImage(Dto.ImageName);
                place.bussiness_pic2 = null;
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);
            }
            if (Dto.FieldName is "PlacePic3")
            {
                await imageUploader.DeleteImage(Dto.ImageName);
                place.bussiness_pic3 = null;
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);
            }
            if (Dto.FieldName is "ModirPic")
            {
                await imageUploader.DeleteImage(Dto.ImageName);
                place.personal_pic = null;
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);
            }
            if (Dto.FieldName is "VisitCartFront")
            {
                await imageUploader.DeleteImage(Dto.ImageName);
                place.visitCart_front = null;
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);

            }
            if (Dto.FieldName is "VisitCartBack")
            {
                await imageUploader.DeleteImage(Dto.ImageName);
                place.visitCart_back = null;
                await UpdateAsync(place, cancellationToken);
                Lucene.EditPlace(place);

            }
            return place;
        }

        public async Task UpdateAddress(EditAddressDto dto, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, dto.placeid);
            place.address = dto.restAddress;
            place.locationId = dto.locationId;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task UpdateRelationWays(UpdateRelationWaysDto dto, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, dto.id);
            place.phone1 = dto.phone1;
            place.phone2 = dto.phone2;
            place.phone3 = dto.phone3;
            place.mob1 = dto.mob1;
            place.mob2 = dto.mob2;
            place.fax = dto.fax;
            place.email = dto.email;
            place.website = dto.website;
            place.telegram = dto.telegram;
            place.instagram = dto.instagram;
            place.whatsapp = dto.whatsapp;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        #endregion

        #region SuperAdminPanel
        public async Task<List<FilteredPlacesForSuperAdmin>> FilterPlacesForSuperAdmin(SearchParametersForSuperAdmin dto, CancellationToken cancellationToken)
        {
            var places = TableNoTracking.Include(p => p.PlaceReport).AsQueryable();
            if (dto.StatusId > 0)
                places = places.Where(p => p.StatusId == dto.StatusId);
            if (dto.CityId > 0)
                places = places.Where(p => p.locationId == dto.CityId);
            if (dto.SearchKey != "null")
                places = places.Where(p => p.tablo.Contains(dto.SearchKey));
            return await places.OrderByDescending(p=>p.Id).Skip((dto.PageIndex - 1) * 10).Take(10).Select(p => new FilteredPlacesForSuperAdmin()
            {
                Id = p.Id,
                StatusId = p.StatusId,
                Tablo = p.tablo,
                CDate = p.cDate.Value.ToString("yyyy-MM-dd"),
                UserId = p.userId,
                ReportCount = p.PlaceReport.Count()
            }).ToListAsync(cancellationToken);
        }

        public async Task ChangeStatusToApproved(long id, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, id);
            place.StatusId = 1;
            place.RejectedDescription = null;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task ChangeStatusToRejected(ChangeStatusToRejectedForSuperAdminDto dto, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, dto.Id);
            place.StatusId = 3;
            place.RejectedDescription = dto.RejectedDescription;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }

        public async Task ChangeStatusToAwaitinig(long id, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, id);
            place.StatusId = 2;
            place.RejectedDescription = null;
            await UpdateAsync(place, cancellationToken);
            Lucene.EditPlace(place);
        }
        #endregion
    }
}
