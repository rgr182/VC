namespace PetStoreBackend.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductCategory { get; set; }

        public ICollection<ClothingAndAccessories> ClothingAndAccessories { get; set; }
        public ICollection<Toy> Toys { get; set; }
        public ICollection<MedicinesAndFood> MedicinesAndFood { get; set; }
    }
}
