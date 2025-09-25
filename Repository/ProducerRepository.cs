using BTickets.Data;
using BTickets.Interfaces;
using BTickets.Models;

namespace BTickets.Repository
{
    public class ProducerRepository: GenericRepository<Producer>, IProducerRepo
    {
        private readonly AppDbContext context;
        public ProducerRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            context = dbcontext;
        }

    }
}
