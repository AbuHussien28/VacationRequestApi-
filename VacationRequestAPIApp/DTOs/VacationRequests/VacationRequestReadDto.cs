namespace VacationRequestAPIApp.DTOs.VacationRequests
{
    public class VacationRequestReadDto
    {
        public int VacationId { get; set; }
        public string NameOfEmployee { get; set; }
        public string TitleVacationRequest { get; set; }
        public string DepartmentName { get; set; }
        public DateTime VacationDateFrom { get; set; }
        public DateTime VacationDateTo { get; set; }
        public DateTime ReturningDate { get; set; }
        public int TotalDays { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string? Notes { get; set; }
    }
}
