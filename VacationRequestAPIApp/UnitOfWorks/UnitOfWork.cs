using VacationRequestAPIApp.Data;
using VacationRequestAPIApp.Interfaces;
using VacationRequestAPIApp.Models;
using VacationRequestAPIApp.Repositories;

namespace VacationRequestAPIApp.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VacationContext context;
        private IGenericRepository<OfficialHoliday> officialHolidayRepository;
        private IGenericRepository<VacationRequest> vacationRequestRepository;
        private IGenericRepository<Department> departmentRepository;
        public UnitOfWork(VacationContext context)
        {
            this.context = context;
        }
        public IGenericRepository<OfficialHoliday> OfficialHolidays
        {
            get {
                if(officialHolidayRepository == null)
                    officialHolidayRepository = new GenericRepository<OfficialHoliday>(context);
                return officialHolidayRepository;
            }
        }

        public IGenericRepository<VacationRequest> VacationRequests
        {
            get {
                if (vacationRequestRepository == null)
                    vacationRequestRepository = new GenericRepository<VacationRequest>(context);
                return vacationRequestRepository;
            }
        }

        public IGenericRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new GenericRepository<Department>(context);
                return departmentRepository;
            }
        }

        public async Task SaveAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
