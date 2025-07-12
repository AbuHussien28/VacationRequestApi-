namespace VacationRequestAPIApp.DTOs.OfficialHolidays
{
    public class OfficialHolidayUpdateDto
    {
        public int Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public string HolidayName { get; set; }
    }
}
