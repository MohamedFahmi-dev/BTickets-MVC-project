namespace BTickets.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IActorsRepo ActorRepository { get; set; }
        IcinemaRepo CinemaRepository { get; set; }
        IProducerRepo ProducerRepository { get; set; }
        IMovieRepo MovieRepository { get; set; }
        IOrdersRepo OrderRepository { get; set; }
        Task<int> Complete();
    }
}
