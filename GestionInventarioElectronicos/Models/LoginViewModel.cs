using System.ComponentModel.DataAnnotations;

namespace GestionInventarioElectronicos.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo Clave es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }
    }
}
