using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VC_API.Domain.Entities

{
    public class Product
    {
        public int ProductId { get; set; }

        public int CategoryName { get; set; }


    }
}
