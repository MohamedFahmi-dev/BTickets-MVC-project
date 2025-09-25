using BTickets.Data;
using BTickets.Interfaces;
using BTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BTickets.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepo
    {
        private readonly AppDbContext context;
        public MovieRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            context = dbcontext;
        }

        public async Task<IEnumerable<Movie>> GetAllWithCinemaAsync()
        {
            return await context.Movies.Include(m => m.Cinema).OrderBy(m => m.Name).ToListAsync();
        }
        public async Task<PaginatedResult<Movie>> GetAllWithCinemaAsync(int page, int pageSize)
        {
            var totalItems = await context.Movies.CountAsync();

            var movies = await context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .OrderByDescending(m => m.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Movie>(movies, totalItems, page, pageSize);
        }

 
        public async Task<Movie> GetAllWithMovieAsync(int id)
        {
            return await  context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
             .FirstOrDefaultAsync(m => m.Id == id);
            

        }
    }
}
