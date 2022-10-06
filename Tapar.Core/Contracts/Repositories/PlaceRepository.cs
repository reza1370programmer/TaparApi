
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
        public PlaceRepository(TaparDbContext dbContext, IImageUploader imageUploader) : base(dbContext)
        {
            this.imageUploader = imageUploader;
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
            place.phone2 = dto.relationWays.phone2 ?? null;
            place.phone3 = dto.relationWays.phone3 ?? null;
            place.mob1 = dto.relationWays.mob1;
            place.mob2 = dto.relationWays.mob2 ?? null;
            place.workTimeId = dto.workingTimeId;
            place.cat3Id = dto.cat3Id;
            place.userId = dto.userId;
            switch (dto.businessPics?.Count)
            {
                case 1:
                    place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0])).Replace('-', ' ');
                    break;
                case 2:
                    place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0])).Replace('-', ' ');
                    place.bussiness_pic2 = (await imageUploader.UploadImage(dto.businessPics[1])).Replace('-', ' ');
                    break;
                case 3:
                    place.bussiness_pic1 = (await imageUploader.UploadImage(dto.businessPics[0])).Replace('-', ' ');
                    place.bussiness_pic2 = (await imageUploader.UploadImage(dto.businessPics[1])).Replace('-', ' ');
                    place.bussiness_pic3 = (await imageUploader.UploadImage(dto.businessPics[2])).Replace('-', ' ');
                    break;
            }
            switch (dto.modirPic?.Count)
            {
                case 1:
                    place.personal_pic = (await imageUploader.UploadImage(dto.modirPic[0])).Replace('-', ' ');
                    break;
            }
            switch (dto.visitCartPics?.Count)
            {
                case 1:
                    place.visitCart_front = (await imageUploader.UploadImage(dto.visitCartPics[0])).Replace('-', ' ');
                    break;
                case 2:
                    place.visitCart_front = (await imageUploader.UploadImage(dto.visitCartPics[0])).Replace('-', ' ');
                    place.visitCart_back = (await imageUploader.UploadImage(dto.visitCartPics[1])).Replace('-', ' ');
                    break;
            }
            place.tags = string.Join(',', dto.tags?.Count > 0 ? dto.tags : "");
            foreach (int item in dto.filters)
            {
                place.place_Filters.Add(new Place_Filter { filterId = item });
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
            await AddAsync(place, cancellationToken);
        }
    }
}
