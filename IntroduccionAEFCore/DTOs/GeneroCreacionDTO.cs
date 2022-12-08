using System.ComponentModel.DataAnnotations;

namespace IntroduccionAEFCore.DTOs
{
    public class GeneroCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
    }
}
