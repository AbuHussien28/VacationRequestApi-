using System.ComponentModel.DataAnnotations;

namespace VacationRequestAPIApp.Models
{
    public class VacationRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime SubmissionDate { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required]
        public DateTime VacationFrom { get; set; }
        [Required]
        public DateTime VacationTo { get; set; }
        public DateTime ReturningDate { get; set; }
        public int TotalDays { get; set; }
        public string? Notes { get; set; }
    }
}
