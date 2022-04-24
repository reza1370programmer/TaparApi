using System.ComponentModel.DataAnnotations;

namespace TaparApi.Common.Dtos.BusinessOffice;

public class BusinessOfficeAddDto
{
    [MaxLength(100)]
    [Required]
    public string title { get; set; }
    [MaxLength(15)]
    public string? phone1 { get; set; }
    [MaxLength(15)]
    public string? phone2 { get; set; }
    [MaxLength(15)]
    public string? phone3 { get; set; }
    [MaxLength(15)]
    public string? fax { get; set; }
    [MaxLength(15)]
    public string? mob1 { get; set; }
    [MaxLength(15)]
    public string? mob2 { get; set; }
    [MaxLength(15)]
    public string? longitude { get; set; }
    [MaxLength(15)]
    public string? latitude { get; set; }
    [MaxLength(20)]
    public string? postCode { get; set; }
    [MaxLength(500)]
    public string? address { get; set; }
    [MaxLength(50)]
    public string viewPic { get; set; }
    [MaxLength(20)]
    public string? area { get; set; }
    [MaxLength(50)]
    public string? website { get; set; }
    [MaxLength(50)]
    public string? email { get; set; }
    [MaxLength(20)]
    public string? telegram { get; set; }
    [MaxLength(15)]
    public string? whatsapp { get; set; }
    [MaxLength(15)]
    public string? instagram { get; set; }
    [Required]
    public int locationId { get; set; }
    [Required]
    public int businessOfficeTypeId { get; set; }
}