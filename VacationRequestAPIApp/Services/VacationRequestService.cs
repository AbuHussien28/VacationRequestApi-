using AutoMapper;
using VacationRequestAPIApp.DTOs.VacationRequests;
using VacationRequestAPIApp.Interfaces;
using VacationRequestAPIApp.Models;

namespace VacationRequestAPIApp.Services
{
    public class VacationRequestService : IVacationRequestService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VacationRequestService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task CreateNewVacationRequest(VacationRequestCreateDto dto)
        {
           var newRequest=mapper.Map<VacationRequest>(dto);
            newRequest.TotalDays = await CalCulateVacationDays(dto.VacationDateFrom, dto.VacationDateTo);
            newRequest.ReturningDate = await GetReturningDate(dto.VacationDateTo);
            await unitOfWork.VacationRequests.AddAsync(newRequest);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<VacationRequestReadDto>> GetAllVacationRequests()
        {
           var VactionRequests=await unitOfWork.VacationRequests.GetAllAsync();
            return mapper.Map<IEnumerable<VacationRequestReadDto>>(VactionRequests);
        }

        public async Task<VacationRequestReadDto?> GetVacationRequestById(int id)
        {
            var vacationRequest =await unitOfWork.VacationRequests.GetByIdAsync(id);
            if (vacationRequest == null)
            {
                throw new KeyNotFoundException($"Vacation request with ID {id} not found.");
            }
            return  mapper.Map<VacationRequestReadDto?>(vacationRequest);
        }

        private async Task<int>CalCulateVacationDays(DateTime vacationDayFrom, DateTime vacationDayTo) 
        {
            var holidays =( await unitOfWork.OfficialHolidays.GetAllAsync()).Where(h=>h.Date>= vacationDayFrom && h.Date<= vacationDayTo).Select(h=>h.Date).ToList();
            int totalDays = 0;
            for(var date = vacationDayFrom; date <= vacationDayTo; date = date.AddDays(1)) 
            {
                if(date.DayOfWeek!=DayOfWeek.Friday&&date.DayOfWeek!=DayOfWeek.Saturday&&!holidays.Contains(date))
                {
                    totalDays++;
                }
            }
            return totalDays;
        }
        private async Task<DateTime>GetReturningDate(DateTime vacationDayTo) 
        {
            var holidays = (await unitOfWork.OfficialHolidays.GetAllAsync()).Where(h => h.Date > vacationDayTo).Select(h => h.Date).ToList();
            DateTime returningDate = vacationDayTo.AddDays(1);
            while (vacationDayTo.DayOfWeek == DayOfWeek.Friday || vacationDayTo.DayOfWeek == DayOfWeek.Saturday || holidays.Contains(vacationDayTo)) 
            {
                returningDate = returningDate.AddDays(1);
            }
            return returningDate;
        }
       
    }
}
