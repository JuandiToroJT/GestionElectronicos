using System.ComponentModel.DataAnnotations;

namespace GestionInventarioElectronicos.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
        public int Cantidad { get; set; }
    }
}
