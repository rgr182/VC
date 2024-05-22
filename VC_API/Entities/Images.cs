using Microsoft.CSharp;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VC_API.Entities
{
    [Keyless]
    public class Images
    {
        
        public int PetId {  get; set; }
        [NotMapped]
        public required IFormFile File { get; set; }
    }
}
