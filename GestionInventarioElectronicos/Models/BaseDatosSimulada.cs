namespace GestionInventarioElectronicos.Models
{
    public static class BaseDatosSimulada
    {
        public static List<Usuario> Usuarios = new List<Usuario>() { new Usuario() { UsuarioId = "admin", Clave = "123", Admin = true }, new Usuario() { UsuarioId = "user", Clave = "123", Admin = false } };
        public static Usuario UsuarioSesion = null;
        public static ArbolBinario ArbolBinario = new ArbolBinario();
        public static ArbolVentas Ventas = new ArbolVentas();
    }
}