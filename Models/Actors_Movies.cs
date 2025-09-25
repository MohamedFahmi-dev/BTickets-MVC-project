namespace BTickets.Models
{
    public class Actors_Movies
    {
        public Actor Actor { get; set; }
        public int ActorId { get;set; }
        public Movie movie { get; set; }
        public int movieId { get; set; }
    }
}
