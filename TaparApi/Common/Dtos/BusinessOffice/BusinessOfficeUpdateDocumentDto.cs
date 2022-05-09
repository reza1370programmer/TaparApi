namespace TaparApi.Common.Dtos.BusinessOffice;

public class BusinessOfficeUpdateDocumentDto
{
    public string? title { get; set; }
    public string? phone1 { get; set; }
    public string? phone2 { get; set; }
    public string? phone3 { get; set; }
    public string? fax { get; set; }
    public string? mob1 { get; set; }
    public string? mob2 { get; set; }
    public string? longitude { get; set; }
    public string? latitude { get; set; }
    public string? postCode { get; set; }
    public string? address { get; set; }
    public string? viewPic { get; set; }
    public string? area { get; set; }
    public string? website { get; set; }
    public string? email { get; set; }
    public string? telegram { get; set; }
    public string? whatsapp { get; set; }
    public string? instagram { get; set; }
    public DateTime? modifiedDate { get; set; }
    public long? modifiedUserId { get; set; }
    public long? businessOfficeId { get; set; }
}