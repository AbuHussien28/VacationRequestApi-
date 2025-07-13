using VacationRequestAPIApp.DTOs;
using VacationRequestAPIApp.DTOs.VacationRequests;

namespace VacationRequestAPIApp.Interfaces
{
    public interface IVacationRequestService
    {
       Task<PagedResultDto<VacationRequestReadDto>> GetAllVacationRequests(int pageNumber,int pageSize);
       Task CreateNewVacationRequest(VacationRequestCreateDto dto);
        Task<VacationRequestReadDto> GetVacationRequestById(int id);
    }
}
