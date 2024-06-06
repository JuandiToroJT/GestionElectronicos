using System.ComponentModel.DataAnnotations;

namespace GestionInventarioElectronicos.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Las caracteristicas son obligatorias")]
        public string Caracteristicas { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, string descripcion, decimal precio, int cantidad, string marca, string modelo, string caracteristicas)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
            Marca = marca;
            Modelo = modelo;
            Caracteristicas = caracteristicas;
        }
    }
}
