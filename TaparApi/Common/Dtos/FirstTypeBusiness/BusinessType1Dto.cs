namespace TaparApi.Common.Dtos.FirstTypeBusiness;

public class BusinessType1Dto
{
    public long id { get; set; }
    public string name { get; set; }
    public string gdesc { get; set; }
    public DateTime? approvedDate { get; set; }
    public DateTime? deactivatedDate { get; set; }
    public DateTime? deletedDate { get; set; }
    public long businessCategoryId { get; set; }
}