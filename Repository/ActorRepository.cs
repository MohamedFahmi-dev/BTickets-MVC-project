using BTickets.Data;
using BTickets.Interfaces;
using BTickets.Models;

namespace BTickets.Repository
{
    public class ActorRepository:GenericRepository<Actor>, IActorsRepo
    {
        private readonly AppDbContext context;

        public ActorRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            context = dbcontext;
        }
    }
}
