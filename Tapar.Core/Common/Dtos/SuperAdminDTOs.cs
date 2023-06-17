

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos
{
    public class SearchParametersForSuperAdmin
    {
        public string? SearchKey { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }
        public int PageIndex { get; set; } = 1;
        public bool UnSolvedReports { get; set; }
    }
    public class FilteredPlacesForSuperAdmin
    {
        public long Id { get; set; }
        public string Tablo { get; set; }
        public int StatusId { get; set; }
        public string? CDate { get; set; }
        public long UserId { get; set; }
        public int ReportCount { get; set; }
        public int UnSolvedReportsCount { get; set; }


    }
    public class ChangeStatusToRejectedForSuperAdminDto
    {
        public long Id { get; set; }
        [MaxLength(200)]
        public string RejectedDescription { get; set; }
    }
    public class ReportListOfPlaceForSuperAdminDTO
    {
        public int Id { get; set; }
        public long PlaceId { get; set; }
        public bool ReportStatus { get; set; }
        public DateTime ReportDate { get; set; }
        public int ReportOptionId { get; set; }
        public string ReportOptionDesc { get; set; }
    }
    public class ChangeReportToSolvedForSuperAdminDTO
    {
        public int Id { get; set; }
        public long PlaceId { get; set; }
    }
}
