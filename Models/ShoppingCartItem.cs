using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
