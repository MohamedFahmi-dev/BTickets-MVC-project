namespace BTickets.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T item);
        void Update(T item);
       void Remove(T item);
       Task<T> GetByIdAsync(int id);
       Task< IEnumerable<T>> GetAllAsync();
        public  Task SaveAsync();
        
    }
    
    
}
