using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VC_API.Domain.Entities
{
    public class Pets
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetsId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public char? Gender { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Cambiar el tipo de datos a int y agregar la anotación EnumDataType
        [EnumDataType(typeof(PetStatus))]
        public int StatusId { get; set; }
    }

    /// <summary>
    /// Enumeración que representa el estado de una mascota.
    /// </summary>
    public enum PetStatus
    { /// <summary>
      /// Indica que la mascota está siendo buscada.
      /// </summary>
        Buscando,
        /// <summary>
        /// Indica que la mascota ha sido reportada como perdida.
        /// </summary>
        Reportado,
        /// <summary>
        /// Indica que la mascota ha sido encontrada.
        /// </summary>
        Encontrado
    }
}
