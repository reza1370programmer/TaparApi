

using Tapar.Core.Common.Dtos.Filters;

namespace Tapar.Core.Common.Dtos.Place
{
    public class PlaceGetDto
    {
        public string tablo { get; set; }
        public string manager { get; set; }
        public string service_description { get; set; }
        public string mob1 { get; set; }
        public string mob2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string fax { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public string telegram { get; set; }
        public string instagram { get; set; }
        public string whatsapp { get; set; }
        public string address { get; set; }
        public string bussiness_pic1 { get; set; }
        public string bussiness_pic2 { get; set; }
        public string bussiness_pic3 { get; set; }
        public string personal_pic { get; set; }
        public string visitCart_front { get; set; }
        public string visitCart_back { get; set; }
        public string special_message { get; set; }
        public string tags { get; set; }
        public string gvalue { get; set; }
        public int like_count { get; set; }
        public string cat1Title { get; set; }
        public string cat2Title { get; set; }
        public string cat3Title { get; set; }
        public int cat1Id { get; set; }
        public int workTimeId { get; set; }
        public WeekDaysDto weekDay { get; set; }
    }
}
