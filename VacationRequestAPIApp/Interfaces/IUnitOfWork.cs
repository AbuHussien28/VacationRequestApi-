using VacationRequestAPIApp.Models;

namespace VacationRequestAPIApp.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<OfficialHoliday> OfficialHolidays { get; }
        IGenericRepository<VacationRequest> VacationRequests { get; }
        IGenericRepository<Department> Departments { get; }
        Task SaveAsync();
       
    }
}
