
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Dtos.Filters;
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
        public IImageUploader imageUploader { get; set; }
        public IHttpContextAccessor httpContextAccessor { get; set; }
        public IMapper mapper { get; set; }
        public ICat2Repsitory cat2Repository { get; set; }
        public PlaceRepository(TaparDbContext dbContext, IImageUploader imageUploader, IHttpContextAccessor httpContextAccessor, IMapper mapper, ICat2Repsitory cat2Repository) : base(dbContext)
        {
            this.imageUploader = imageUploader;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.cat2Repository = cat2Repository;
        }

        public async Task AddPlace(PlaceAddDto dto, CancellationToken cancellationToken)
        {
            Place place = new Place();
            place.tablo = dto.tablo;
            place.service_description = dto.description;
            place.manager = dto.modir;
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
            place.userId = dto.userId;
            switch (dto.businessPics?.Count)
            {
                case 1:
                    place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0]));
                    break;
                case 2:
                    place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0]));
                    place.bussiness_pic2 = (await imageUploader.UploadImage(dto.businessPics[1]));
                    break;
                case 3:
                    place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0]));
                    place.bussiness_pic2 = (await imageUploader.UploadImage(dto.businessPics[1]));
                    place.bussiness_pic3 = (await imageUploader.UploadImage(dto.businessPics[2]));
                    break;
            }
            switch (dto.modirPic?.Count)
            {
                case 1:
                    place.personal_pic = (await imageUploader.UploadImage(dto.modirPic[0]));
                    break;
            }
            switch (dto.visitCartPics?.Count)
            {
                case 1:
                    place.visitCart_front = (await imageUploader.UploadImage(dto.visitCartPics[0]));
                    break;
                case 2:
                    place.visitCart_front = (await imageUploader.UploadImage(dto.visitCartPics[0]));
                    place.visitCart_back = (await imageUploader.UploadImage(dto.visitCartPics[1]));
                    break;
            }
            place.tags = dto.tags?.Count() > 0 ? String.Join(',', dto.tags?.ToArray()!) : null!;
            foreach (int item in dto.filters)
            {
                place.place_Filters.Add(new Place_Filter { filterId = item,placeId=place.Id });
            }
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
            place.cDate = DateTime.Now;
            place.cUserId = long.Parse(httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await AddAsync(place, cancellationToken);
        }

        public async Task<List<Place>> SearchPlace(string SearchKey, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(p => p.tablo.Contains(SearchKey) || p.tags.Contains(SearchKey)).ToListAsync(cancellationToken);
        }

        public async Task<PlaceGetDto?> GetPlaceById(long id, CancellationToken cancellationToken)
        {
            PlaceGetDto getPlace = new();
            var place = await TableNoTracking.
                Include(p => p.weekDay).
                Include(p => p.cat3).
                ThenInclude(p => p.cat2).
                ThenInclude(p => p.cat1).
                AsSplitQuery().
                SingleOrDefaultAsync(p => p.Id == id);
            if (place != null)
            {
                getPlace = mapper.Map<PlaceGetDto>(place);
                getPlace.cat1Id = place.cat3.cat2.cat1.Id;
                getPlace.cat1Title = place.cat3.cat2.cat1.name;
                getPlace.cat2Title = place.cat3.cat2.name;
                getPlace.cat3Title = place.cat3.name;
                //getPlace.filters = mapper.Map<IEnumerable<FilterDto>>(await cat2Repository.GetCat2Filters(place.cat3.cat2.Id, cancellationToken));
                return getPlace;
            }
            return null;


        }
    }
}
