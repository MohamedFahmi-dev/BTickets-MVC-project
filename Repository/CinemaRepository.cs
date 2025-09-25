using BTickets.Data;
using BTickets.Interfaces;
using BTickets.Models;

namespace BTickets.Repository
{
    public class CinemaRepository:GenericRepository<Cinema>, IcinemaRepo
    {
        private readonly AppDbContext context;
        public CinemaRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            context = dbcontext;
        }
    }
    
}

