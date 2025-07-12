using System.ComponentModel.DataAnnotations;

namespace VacationRequestAPIApp.Models
{
    public class OfficialHoliday
    {
        [Key]
        public int OfficialHolidayId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string holidayTitle { get; set; }
    }
}
