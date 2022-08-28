using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place:BaseEntity<long>
    {
        public List<SubPlace> subPlaces { get; set; }
    }
}
