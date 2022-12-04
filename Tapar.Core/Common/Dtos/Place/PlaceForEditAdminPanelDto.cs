using Tapar.Core.Common.Dtos.DynamicFields;
using Tapar.Core.Common.Dtos.Filters;
using Tapar.Core.Common.Dtos.Location;

namespace Tapar.Core.Common.Dtos.Place
{
    public class PlaceForEditAdminPanelDto
    {
        public int cat1Id { get; set; }
        public int cat2Id { get; set; }
        public List<int> filterids { get; set; }
        public List<FilterDto> filters { get; set; }
        public List<CatDto> cat2 { get; set; }
        public List<CatDto> cat3 { get; set; }
        public List<LocationDto> ostan { get; set; }
        public List<LocationDto> shahrestan { get; set; }
        public List<DynamicFieldsDto> dynamicFields { get; set; }
        public Data.Entities.Place place { get; set; }
    }
}
