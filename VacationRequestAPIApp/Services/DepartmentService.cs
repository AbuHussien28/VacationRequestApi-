using AutoMapper;
using VacationRequestAPIApp.DTOs.Department;
using VacationRequestAPIApp.Interfaces;
using VacationRequestAPIApp.Models;

namespace VacationRequestAPIApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddDepartmentToSystem(DepartmentCreateDto dto)
        {
            var entity = mapper.Map<Department>(dto);
            unitOfWork.Departments.AddAsync(entity);
            await unitOfWork.SaveAsync();
        }

        public Task DeleteDepartment(int id)
        {
            unitOfWork.Departments.Delete(id);
            return unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DepartmentReadDto>> GetAllDepartment()
        {
            var Departments=await unitOfWork.Departments.GetAllAsync();
            return mapper.Map<IEnumerable<DepartmentReadDto>>(Departments);
        }

        public Task UpdateDepartment(DepartmentUpdateDto dto)
        {
            var entity = mapper.Map<Department>(dto);
            unitOfWork.Departments.Update(entity);
            return unitOfWork.SaveAsync();
        }
    }
}
