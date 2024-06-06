namespace GestionInventarioElectronicos.Models
{
    public class ArbolBinario
    {
        public Nodo Raiz { get; private set; }

        public void Insertar(Producto producto)
        {
            if (Raiz == null)
                Raiz = new Nodo(producto);
            else
                InsertarRecursivo(Raiz, producto);
        }

        private void InsertarRecursivo(Nodo nodo, Producto producto)
        {
            if (producto.Id < nodo.Producto.Id)
            {
                if (nodo.Izquierdo == null)
                    nodo.Izquierdo = new Nodo(producto);
                else
                    InsertarRecursivo(nodo.Izquierdo, producto);
            }
            else
            {
                if (nodo.Derecho == null)
                    nodo.Derecho = new Nodo(producto);
                else
                    InsertarRecursivo(nodo.Derecho, producto);
            }
        }

        public void Eliminar(int id)
        {
            Raiz = EliminarRecursivo(Raiz, id);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int id)
        {
            if (nodo == null)
                return nodo;

            if (id < nodo.Producto.Id)
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, id);
            else if (id > nodo.Producto.Id)
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, id);
            else
            {
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                else if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                nodo.Producto = MinimoValor(nodo.Derecho);
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Producto.Id);
            }

            return nodo;
        }

        private Producto MinimoValor(Nodo nodo)
        {
            Producto minValor = nodo.Producto;
            while (nodo.Izquierdo != null)
            {
                minValor = nodo.Izquierdo.Producto;
                nodo = nodo.Izquierdo;
            }
            return minValor;
        }

        public Producto Buscar(int id)
        {
            return BuscarRecursivo(Raiz, id);
        }

        private Producto BuscarRecursivo(Nodo nodo, int id)
        {
            if (nodo == null)
                return null;
            if (id == nodo.Producto.Id)
                return nodo.Producto;
            if (id < nodo.Producto.Id)
                return BuscarRecursivo(nodo.Izquierdo, id);
            else
                return BuscarRecursivo(nodo.Derecho, id);
        }

        public List<Producto> RecorrerPreOrden()
        {
            List<Producto> productos = new List<Producto>();
            RecorrerPreOrdenRecursivo(Raiz, productos);
            return productos;
        }

        private void RecorrerPreOrdenRecursivo(Nodo nodo, List<Producto> productos)
        {
            if (nodo != null)
            {
                productos.Add(nodo.Producto);
                RecorrerPreOrdenRecursivo(nodo.Izquierdo, productos);
                RecorrerPreOrdenRecursivo(nodo.Derecho, productos);
            }
        }

        public int ContarProductos()
        {
            return ContarProductosRecursivo(Raiz);
        }

        private int ContarProductosRecursivo(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            return 1 + ContarProductosRecursivo(nodo.Izquierdo) + ContarProductosRecursivo(nodo.Derecho);
        }

        public List<Producto> BuscarProductos(string nombre = null, string marca = null, string modelo = null)
        {
            List<Producto> productos = new List<Producto>();
            BuscarProductosRecursivo(Raiz, nombre, marca, modelo, productos);
            return productos;
        }

        private void BuscarProductosRecursivo(Nodo nodo, string nombre, string marca, string modelo, List<Producto> productos)
        {
            if (nodo != null)
            {
                bool coincide = false;

                if (!string.IsNullOrEmpty(nombre) && nodo.Producto.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                    coincide = true;

                if (!string.IsNullOrEmpty(marca) && nodo.Producto.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase))
                    coincide = true;

                if (!string.IsNullOrEmpty(modelo) && nodo.Producto.Modelo.Contains(modelo, StringComparison.OrdinalIgnoreCase))
                    coincide = true;

                if (coincide || (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(marca) && string.IsNullOrEmpty(modelo)))
                    productos.Add(nodo.Producto);

                BuscarProductosRecursivo(nodo.Izquierdo, nombre, marca, modelo, productos);
                BuscarProductosRecursivo(nodo.Derecho, nombre, marca, modelo, productos);
            }
        }
    }

    public class Nodo
    {
        public Producto Producto { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(Producto producto)
        {
            Producto = producto;
            Izquierdo = null;
            Derecho = null;
        }
    }

}
