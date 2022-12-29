using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Common;
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
        public ICat2Repsitory cat2Repsitory { get; set; }
        public IImageUploader imageUploader { get; set; }
        public IHttpContextAccessor httpContextAccessor { get; set; }
        ICat3Repository cat3Repository { get; set; }
        ILocationRepository locationRepository { get; set; }
        public IMapper mapper { get; set; }
        public IDynamicFieldsRepsitory dynamicFieldsRepsitory { get; set; }
        #endregion

        #region Constructor
        public PlaceRepository(
         TaparDbContext dbContext,
         IImageUploader imageUploader,
         IHttpContextAccessor httpContextAccessor,
         ICat3Repository cat3Repository,
         ILocationRepository locationRepository,
         IMapper mapper,
         ICat2Repsitory cat2Repsitory,
         IDynamicFieldsRepsitory dynamicFieldsRepsitory) : base(dbContext)
        {
            this.cat3Repository = cat3Repository;
            this.locationRepository = locationRepository;
            this.imageUploader = imageUploader;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.cat2Repsitory = cat2Repsitory;
            this.dynamicFieldsRepsitory = dynamicFieldsRepsitory;
        }
        #endregion

        #region Methods
        public async Task AddPlace(PlaceAddDto dto, CancellationToken cancellationToken)
        {
            var ostanabbriviation = await GetLocationAbbriviation(dto.address.ostan.ToInt(), cancellationToken);
            var shahrestanabbriviation = await GetLocationAbbriviation(dto.address.shahrestan.ToInt(), cancellationToken);
            var cat1id = (await GetCat1Id_Abbriviation(dto.cat3Id, cancellationToken))["cat1id"];
            var cat1abbriviation = (await GetCat1Id_Abbriviation(dto.cat3Id, cancellationToken))["cat1abbriviation"];

            Place place = new Place();
            place.tablo = dto.tablo;
            place.service_description = dto.description;
            place.manager = dto.modir;
            place.taparcode = cat1abbriviation + ostanabbriviation + shahrestanabbriviation + (await TableNoTracking.CountAsync() + 1);
            place.gvalue = dto.gValue;
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
            place.cat3Id = dto.cat3Id;
            place.userId = long.Parse(httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (dto.businessPics == null)
            {
                var picname = GetImageNameByCat1Id(cat1id.ToInt());
                place.bussiness_pic1 = picname;
                place.bussiness_pic2 = picname;
                place.bussiness_pic3 = picname;
            }
            else
            {
                switch (dto.businessPics?.Count)
                {
                    case 1:
                        place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0]));
                        place.bussiness_pic2 = GetImageNameByCat1Id(cat1id.ToInt());
                        place.bussiness_pic3 = GetImageNameByCat1Id(cat1id.ToInt());
                        break;
                    case 2:
                        place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0]));
                        place.bussiness_pic2 = (await imageUploader.UploadImage(dto.businessPics[1]));
                        place.bussiness_pic3 = GetImageNameByCat1Id(cat1id.ToInt());
                        break;
                    case 3:
                        place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0]));
                        place.bussiness_pic2 = (await imageUploader.UploadImage(dto.businessPics[1]));
                        place.bussiness_pic3 = (await imageUploader.UploadImage(dto.businessPics[2]));
                        break;
                }
            }
            if (dto.modirPic?.Count > 0)
            {
                place.personal_pic = (await imageUploader.UploadImage(dto.modirPic[0]));
            }
            else
            {
                place.personal_pic = "modirpic.jpg";
            }
            if (dto.visitCartPics?.Count > 0)
            {
                switch (dto.visitCartPics?.Count)
                {
                    case 1:
                        place.visitCart_front = (await imageUploader.UploadImage(dto.visitCartPics[0]));
                        place.visitCart_back = null;
                        break;
                    case 2:
                        place.visitCart_front = (await imageUploader.UploadImage(dto.visitCartPics[0]));
                        place.visitCart_back = (await imageUploader.UploadImage(dto.visitCartPics[1]));
                        break;
                }
            }
            else
            {
                place.visitCart_back = null;
                place.visitCart_front = null;
            }
            place.tags = dto.tags?.Count() > 0 ? String.Join(',', dto.tags?.ToArray()!) : null!;
            if (dto.filters?.Count > 0)
            {
                foreach (int item in dto.filters)
                {
                    place.place_Filters?.Add(new Place_Filter { filterId = item, placeId = place.Id });
                }
            }
            if (place.workTimeId == 3)
            {
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
        }
        public async Task<List<Place>> SearchPlace(SearchParams searchParams, CancellationToken cancellationToken)
        {
            IQueryable<Place> query = TableNoTracking.Include(p => p.weekDay).
            Include(p => p.cat3).
            ThenInclude(p => p.cat2).
            ThenInclude(p => p.cat1).
            AsSplitQuery().AsQueryable();

            if (searchParams?.filters?.Count() > 0)
            {

                //query = query.SelectMany(p => p.place_Filters)
                //    .Where(a => searchParams.filters.Contains(a.filterId)).Include(p => p.place)
                //    .Select(q => q.place).Distinct();

                query = query.Include(p => p.place_Filters).Where(p => p.place_Filters.Any(q => searchParams.filters.Contains(q.filterId)));

            }

            if (searchParams.searchKey != null)
            {
                query = query.Where(p => p.tablo.Contains(searchParams.searchKey) || p.tags.Contains(searchParams.searchKey));
            }

            if (searchParams.cat3Id != null)
                query = query.Where(p => p.cat3Id.ToString() == searchParams.cat3Id);


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
                return place.like_count;
            }
            return -1;
        }
        public async Task AddView(long placeId, CancellationToken cancellationToken)
        {
            var place = await GetByIdAsync(cancellationToken, placeId);
            place.view_count += 1;
            await UpdateAsync(place, cancellationToken);
        }
        public async Task<string> GetLocationAbbriviation(int locationid, CancellationToken cancellationToken)
        {
            var location = await locationRepository.GetByIdAsync(cancellationToken, locationid);
            var locationAbbrivaition = location.abbreviation;
            return locationAbbrivaition;
        }
        public async Task<Dictionary<string, string>> GetCat1Id_Abbriviation(int cat3id, CancellationToken cancellationToken)
        {
            var cat3 = await cat3Repository.TableNoTracking.Include(p => p.cat2).ThenInclude(p => p.cat1).SingleOrDefaultAsync(p => p.Id == cat3id, cancellationToken);
            var cat1id = cat3.cat2.cat1.Id;
            var cat1abbriviation = cat3.cat2.cat1.abbreviation;
            return new Dictionary<string, string>()
            {
                {"cat1id",cat1id.ToString() },
                {"cat1abbriviation",cat1abbriviation },
            };
        }
        public string GetImageNameByCat1Id(int cat1id)
        {
            switch (cat1id)
            {
                case 1:
                    return "health.jpg";
                case 2:
                    return "economy.jpg";
                case 3:
                    return "research.jpg";
                case 4:
                    return "government.jpg";
                case 5:
                    return "practice.jpg";

            }
            return "";
        }

        #region UserPanel
        public async Task<List<Place>> GetPlacesByUserId(long userid, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(p => p.userId == userid).ToListAsync(cancellationToken);
        }

        public async Task<Place> GetPlaceCurrentCategory(long placeid, CancellationToken cancellationToken)
        {
            var place = await TableNoTracking.Include(p => p.cat3).ThenInclude(p => p.cat2).ThenInclude(p => p.cat1).SingleOrDefaultAsync(p => p.Id == placeid, cancellationToken);
            return place;
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
        #endregion

        #endregion

    }
}
