

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos
{
    public class SearchParametersForSuperAdmin
    {
        public string? SearchKey { get; set; }
        public int StatusId { get; set; }
    }
    public class FilteredPlacesForSuperAdmin
    {
        public long Id { get; set; }
        public string Tablo { get; set; }
        public int StatusId { get; set; }
    }
    public class ChangeStatusToRejectedForSuperAdminDto
    {
        public long Id { get; set; }
        [MaxLength(200)]
        public string RejectedDescription { get; set; }
    }
}
