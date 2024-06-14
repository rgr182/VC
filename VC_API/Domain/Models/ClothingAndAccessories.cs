using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetStoreBackend.Models
{
    public class ClothingAndAccessories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClothingAndAccessoriesId { get; set; }
        public int ProductId { get; set; }
        public string CategoryType { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageURL { get; set; }
        public Product Product { get; set; }
    }
}
