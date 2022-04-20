using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class BusinessOfficeType:BaseEntity
{
    [StringLength(30)]
    public string name { get; set; }
    [StringLength(100)]
    public string gdesc { get; set; }
    public List<BusinessOffice> BusinessOffices { get; set; }
}