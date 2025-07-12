using AutoMapper;
using VacationRequestAPIApp.DTOs.OfficialHolidays;
using VacationRequestAPIApp.Interfaces;
using VacationRequestAPIApp.Models;

namespace VacationRequestAPIApp.Services
{
    public class OfficialHolidayService : IOfficialHolidayService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OfficialHolidayService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddHolidayToSystem(OfficialHolidayCreateDto dto)
        {
            var entity = mapper.Map<OfficialHoliday>(dto);
            await unitOfWork.OfficialHolidays.AddAsync(entity);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteHoliday(int id)
        {
             unitOfWork.OfficialHolidays.Delete(id);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OfficialHolidayReadDto>> GetAllHolidayDays()
        {
            var holidays = await unitOfWork.OfficialHolidays.GetAllAsync();
            return mapper.Map<IEnumerable<OfficialHolidayReadDto>>(holidays);

        }
    }
}
