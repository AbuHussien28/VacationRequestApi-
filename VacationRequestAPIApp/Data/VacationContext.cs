using Microsoft.EntityFrameworkCore;
using VacationRequestAPIApp.Models;

namespace VacationRequestAPIApp.Data
{
    public class VacationContext:DbContext
    {
        public VacationContext()
        {
            
        }
        public VacationContext(DbContextOptions<VacationContext> options) : base(options)
        {
        }
        public DbSet<VacationRequest> VacationRequest { get; set; }
        public DbSet<OfficialHoliday> OfficialHolidays { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
