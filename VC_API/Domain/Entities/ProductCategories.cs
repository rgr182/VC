using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VC_API.Domain.Entities
{
    public class ProductCategory
    { 
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
