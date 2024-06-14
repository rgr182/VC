using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetStoreBackend.Models
{
    public class Toys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToysId { get; set; }
        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageURL { get; set; }
        public Product Product { get; set; }
    }
}
