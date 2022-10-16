
using Microsoft.AspNetCore.Http;

namespace Tapar.Core.Common.Dtos.Place
{
    public class PlaceAddDto
    {
        public string tablo { get; set; }
        public string description { get; set; }
        public string? modir { get; set; }
        public string? gValue { get; set; }
        public long userId { get; set; }
        public int cat3Id { get; set; }
        public List<int> filters { get; set; }
        public Address address { get; set; }
        public RelationWays relationWays { get; set; }
        public int workingTimeId { get; set; }
        public List<WorkingDays> workingDays { get; set; }
        public List<string>? tags { get; set; }
        public List<IFormFile>? businessPics { get; set; }
        public List <IFormFile>? modirPic { get; set; }
        public List<IFormFile>? visitCartPics { get; set; }
    }
    public class Address
    {
        public string ostan { get; set; }
        public string shahrestan { get; set; }
        public string restAddress { get; set; }
    }
    public class RelationWays
    {
        public string phone1 { get; set; }
        public string? phone2 { get; set; }
        public string? phone3 { get; set; }
        public string mob1 { get; set; }
        public string? mob2 { get; set; }
        public string? fax { get; set; }
        public string? email { get; set; }
        public string? website { get; set; }
        public string? telegram { get; set; }
        public string? instagram { get; set; }
        public string? whatsapp { get; set; }
    }
    public class WorkingDays
    {
        public int id { get; set; }
        public bool am { get; set; }
        public bool pm { get; set; }
    }
}
