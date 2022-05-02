using TaparApi.Common.Dtos.BusinessOffice;

namespace TaparApi.Common.Dtos.Business;

public class BusinessSelectDto
{
    public string? titel { get; set; }
    public string? serviceDesc { get; set; }
    public string? phone { get; set; }
    public string? workTimeDesc { get; set; }
    public string? specialMessage { get; set; }
    public string? address { get; set; }
    public string? workTime { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? gender { get; set; }
    public string? gdesc { get; set; }
    public string? nationalCode { get; set; }
    public string? gvalue { get; set; }
    public BusinessOfficeSelectDto? businessOfficeDto { get; set; }
}