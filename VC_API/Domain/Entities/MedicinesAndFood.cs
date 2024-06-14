using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace VC_API.Domain.Entities
{
    public class MedicinesAndFood
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicinesAndFoodId { get; set; }

        public int ProductId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImageURL { get; set; }


    }
}
