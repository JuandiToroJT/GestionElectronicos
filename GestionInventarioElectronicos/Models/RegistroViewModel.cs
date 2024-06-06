using System.ComponentModel.DataAnnotations;

namespace GestionInventarioElectronicos.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo Clave es obligatorio.")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "El campo Confirmar Clave es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Clave")]
        [Compare("Clave", ErrorMessage = "La clave y la confirmación de clave no coinciden.")]
        public string ConfirmarClave { get; set; }
    }
}
