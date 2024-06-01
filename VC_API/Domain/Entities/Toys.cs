using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VC_API.Domain.Entities
{
    public class Toys
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToysId { get; set; }

        public int ProductId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImageURL { get; set; }
    }
    
}
