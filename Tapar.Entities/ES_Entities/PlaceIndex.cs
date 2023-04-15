


//namespace Tapar.Data.ES_Entities
//{
//    [ElasticsearchType(IdProperty = nameof(Id))]
//    public class PlaceIndex
//    {
//        [Keyword]
//        public long Id { get; set; }
//        public string tablo { get; set; }
//        public string manager { get; set; }
//        [Keyword]
//        public string? taparcode { get; set; }
//        public string? service_description { get; set; } = null;
//        public string? RejectedDescription { get; set; }
//        [Keyword]
//        public string? mob1 { get; set; } = null;
//        [Keyword]
//        public string? mob2 { get; set; } = null;
//        [Keyword]
//        public string? phone1 { get; set; } = null;
//        [Keyword]
//        public string? phone2 { get; set; } = null;
//        [Keyword]
//        public string? phone3 { get; set; } = null;
//        [Keyword]
//        public string? fax { get; set; } = null;
//        [Keyword]
//        public string? website { get; set; } = null;
//        [Keyword]
//        public string? email { get; set; } = null;
//        [Keyword]
//        public string? telegram { get; set; } = null;
//        [Keyword]
//        public string? instagram { get; set; } = null;
//        [Keyword]
//        public string? whatsapp { get; set; } = null;
//        [Keyword]
//        public string? address { get; set; } = null;
//        [Keyword]
//        public string? bussiness_pic1 { get; set; } = null;
//        [Keyword]
//        public string? bussiness_pic2 { get; set; } = null;
//        [Keyword]
//        public string? bussiness_pic3 { get; set; } = null;
//        [Keyword]
//        public string? personal_pic { get; set; } = null;
//        [Keyword]
//        public string? visitCart_front { get; set; } = null;
//        [Keyword]
//        public string? visitCart_back { get; set; } = null;
//        public string? special_message { get; set; } = null;
//        [Keyword]
//        public int? like_count { get; set; } = 0;
//        [Keyword]
//        public int? view_count { get; set; } = 0;
//        public bool on_off { get; set; } = true;
//        [Keyword]
//        public int locationId { get; set; }
//        [Keyword]
//        public int StatusId { get; set; }
//        public WeekDaysDtoForEs? weekDay { get; set; }
//        public long userId { get; set; }
//        public int workTimeId { get; set; }
//        public List<CommnetDtoForEs> comments { get; set; }
//    }
//    public class CommnetDtoForEs
//    {
//        public string text { get; set; }
//        public DateTime create_date { get; set; }
//        public bool status { get; set; } = false;
//    }
//    public class WeekDaysDtoForEs
//    {
//        public int saturday { get; set; }
//        public int sunday { get; set; }
//        public int monday { get; set; }
//        public int tuesday { get; set; }
//        public int wednesday { get; set; }
//        public int thursday { get; set; }
//        public int friday { get; set; }
//    }
//}
