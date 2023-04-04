namespace Tapar.Core.Common.Dtos.LuceneDto
{
    public class LuceneDto
    {
        public long Id { get; set; }
        public string tablo { get; set; }
        public string manager { get; set; }
        public string? taparcode { get; set; }
        public string? service_description { get; set; } = null;
        public string? mob1 { get; set; } = null;
        public string? mob2 { get; set; } = null;
        public string? phone1 { get; set; } = null;
        public string? phone2 { get; set; } = null;
        public string? phone3 { get; set; } = null;
        public string? fax { get; set; } = null;
        public string? website { get; set; } = null;
        public string? email { get; set; } = null;
        public string? telegram { get; set; } = null;
        public string? instagram { get; set; } = null;
        public string? whatsapp { get; set; } = null;
        public string? address { get; set; } = null;
        public string? bussiness_pic1 { get; set; } = null;
        public string? bussiness_pic2 { get; set; } = null;
        public string? bussiness_pic3 { get; set; } = null;
        public string? personal_pic { get; set; } = null;
        public string? visitCart_front { get; set; } = null;
        public string? visitCart_back { get; set; } = null;
        public string? special_message { get; set; } = null;
        public int like_count { get; set; } = 0;
        public int view_count { get; set; } = 0;
        public bool on_off { get; set; } = true;
        public int locationId { get; set; }
        public int StatusId { get; set; }
        public int saturday { get; set; }
        public int sunday { get; set; }
        public int monday { get; set; }
        public int tuesday { get; set; }
        public int wednesday { get; set; }
        public int thursday { get; set; }
        public int friday { get; set; }
        public long userId { get; set; }
        public int workTimeId { get; set; }
    }
}
