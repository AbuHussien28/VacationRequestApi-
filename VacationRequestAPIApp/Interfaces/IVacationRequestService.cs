using VacationRequestAPIApp.DTOs.VacationRequests;

namespace VacationRequestAPIApp.Interfaces
{
    public interface IVacationRequestService
    {
       Task<IEnumerable<VacationRequestReadDto>> GetAllVacationRequests();
       Task CreateNewVacationRequest(VacationRequestCreateDto dto);
        Task<VacationRequestReadDto> GetVacationRequestById(int id);
    }
}
