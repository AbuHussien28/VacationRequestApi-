using System.ComponentModel.DataAnnotations;

namespace VacationRequestAPIApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string departmentName { get; set; }
        public virtual ICollection<VacationRequest> VacationRequests { get; set; }
    }
}
