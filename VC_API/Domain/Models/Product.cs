namespace PetStoreBackend.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductCategory { get; set; }
        public ClothingAndAccessories ProductAccesory{ get; set; }
    }
}
