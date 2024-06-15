using Microsoft.CSharp;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VC_API.Entities
{
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string ImageURL { get; set; }
        
        public int PetId {  get; set; }
        [ForeignKey("PetId")]
        public Pets pets { get; set; }
    }
}
