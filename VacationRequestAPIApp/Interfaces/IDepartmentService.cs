using VacationRequestAPIApp.DTOs.Department;
using VacationRequestAPIApp.DTOs.OfficialHolidays;

namespace VacationRequestAPIApp.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentReadDto>> GetAllDepartment();
        Task AddDepartmentToSystem(DepartmentCreateDto dto);
        Task UpdateDepartment(DepartmentUpdateDto dto);
        Task DeleteDepartment(int id);
    }
}
