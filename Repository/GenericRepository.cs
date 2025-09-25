


using BTickets.Data;
using BTickets.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BTickets.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T item)=>await context.Set<T>().AddAsync(item);


        public void Update(T item)=>context.Update(item);
        

        

        public async Task<IEnumerable<T>> GetAllAsync()=>  await context.Set<T>().ToListAsync();
        

        public async Task<T> GetByIdAsync(int id)=> await context.Set<T>().FindAsync(id);


        public async Task SaveAsync() => await context.SaveChangesAsync();

        public void Remove(T item)
        {
           context.Set<T>().Remove(item);
        }
    }
}
