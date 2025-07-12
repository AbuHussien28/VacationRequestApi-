using System.ComponentModel.DataAnnotations;

namespace VacationRequestAPIApp.DTOs.VacationRequests
{
    public class VacationRequestCreateDto
    {
        [Required(ErrorMessage = "Please enter the employee's name.")]
        public string NameOfEmployee { get; set; }
        [Required(ErrorMessage = "Please enter the Title")]
        public string TitleVacationRequest { get; set; }
        public int DepartmentOfEmployeeId { get; set; }
        public DateTime VacationDateFrom { get; set; }
        public DateTime VacationDateTo { get; set; }
        public string? Notes { get; set; }
    }
}
