using BTickets.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace BTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory movieCategory { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
        public Producer Producer { get; set; }
        public int ProducerId { get; set; }
        public List<Actors_Movies> actors_Movies { get; set; }


    }
}
