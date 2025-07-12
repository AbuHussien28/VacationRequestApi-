using VacationRequestAPIApp.DTOs.OfficialHolidays;

namespace VacationRequestAPIApp.Interfaces
{
    public interface IOfficialHolidayService
    {
        Task<IEnumerable<OfficialHolidayReadDto>> GetAllHolidayDays();
        Task AddHolidayToSystem(OfficialHolidayCreateDto dto);
        Task DeleteHoliday(int id);
    }
}
