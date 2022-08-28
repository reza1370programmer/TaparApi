namespace TaparApi.Common.Dtos.BusinessCategory;

public class BusinessCategoryDto
{
    public long id { get; set; }
    public string name { get; set; }
    public string gdesc { get; set; }
    public DateTime? approvedDate { get; set; }
    public DateTime? deactivatedDate { get; set; }
    public DateTime? deletedDate { get; set; }
}