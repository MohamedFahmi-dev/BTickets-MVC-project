using BTickets.Data;
using BTickets.Interfaces;

namespace BTickets.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext _context)
        {
            CinemaRepository = new CinemaRepository(_context);
            ActorRepository = new ActorRepository(_context);
            ProducerRepository = new ProducerRepository(_context);
            MovieRepository = new MovieRepository(_context);
            OrderRepository = new OrderRepository(_context);
            this._context = _context;
        }

        public IActorsRepo ActorRepository { get; set; }
        public IcinemaRepo CinemaRepository { get; set; }
        public IProducerRepo ProducerRepository { get; set; }
        public IMovieRepo MovieRepository { get; set; }
        public IOrdersRepo OrderRepository { get; set; }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
