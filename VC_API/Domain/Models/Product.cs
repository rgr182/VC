namespace PetStoreBackend.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductCategory { get; set; }
        public ClothingAndAccessories ProductAccesory{ get; set; }
    }
}
