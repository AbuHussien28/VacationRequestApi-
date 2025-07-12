using Microsoft.EntityFrameworkCore;
using VacationRequestAPIApp.Data;
using VacationRequestAPIApp.Interfaces;

namespace VacationRequestAPIApp.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly VacationContext context;

        public GenericRepository(VacationContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
           await context.AddAsync(entity);
        }

        public void Delete(int id)
        {
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(id));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public void Update(TEntity entity)
        {
           context.Entry(entity).State = EntityState.Modified;
        }
    }
}
