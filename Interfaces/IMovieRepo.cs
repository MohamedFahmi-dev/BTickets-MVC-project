using BTickets.Models;

namespace BTickets.Interfaces
{
    public interface IMovieRepo:IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllWithCinemaAsync();
        public Task<PaginatedResult<Movie>> GetAllWithCinemaAsync(int page, int pageSize);

        Task<Movie> GetAllWithMovieAsync(int id);
       
    }
}
