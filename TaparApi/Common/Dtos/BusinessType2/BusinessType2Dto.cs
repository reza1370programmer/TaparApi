namespace TaparApi.Common.Dtos.BusinessType2;

public class BusinessType2Dto
{
    public long id { get; set; }
    public string name { get; set; }
    public string gdesc { get; set; }
    public DateTime? approvedDate { get; set; }
    public DateTime? deactivatedDate { get; set; }
    public DateTime? deletedDate { get; set; }
    public long businessType1Id { get; set; }
}