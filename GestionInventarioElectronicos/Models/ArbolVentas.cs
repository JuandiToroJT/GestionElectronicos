namespace GestionInventarioElectronicos.Models
{
    public class ArbolVentas
    {
        public NodoVenta Raiz { get; private set; }

        public void Insertar(Venta venta)
        {
            if (Raiz == null)
                Raiz = new NodoVenta(venta);
            else
                InsertarRecursivo(Raiz, venta);
        }

        private void InsertarRecursivo(NodoVenta nodoVenta, Venta venta)
        {
            if (venta.Id < nodoVenta.Venta.Id)
            {
                if (nodoVenta.Izquierdo == null)
                    nodoVenta.Izquierdo = new NodoVenta(venta);
                else
                    InsertarRecursivo(nodoVenta.Izquierdo, venta);
            }
            else
            {
                if (nodoVenta.Derecho == null)
                    nodoVenta.Derecho = new NodoVenta(venta);
                else
                    InsertarRecursivo(nodoVenta.Derecho, venta);
            }
        }

        public List<Venta> RecorrerPreOrden()
        {
            List<Venta> ventas = new List<Venta>();
            RecorrerPreOrdenRecursivo(Raiz, ventas);
            return ventas;
        }

        private void RecorrerPreOrdenRecursivo(NodoVenta nodoVenta, List<Venta> ventas)
        {
            if (nodoVenta != null)
            {
                ventas.Add(nodoVenta.Venta);
                RecorrerPreOrdenRecursivo(nodoVenta.Izquierdo, ventas);
                RecorrerPreOrdenRecursivo(nodoVenta.Derecho, ventas);
            }
        }

        public int ContarVentas()
        {
            return ContarVentasRecursivo(Raiz);
        }

        private int ContarVentasRecursivo(NodoVenta nodoVenta)
        {
            if (nodoVenta == null)
                return 0;

            return 1 + ContarVentasRecursivo(nodoVenta.Izquierdo) + ContarVentasRecursivo(nodoVenta.Derecho);
        }
    }

    public class NodoVenta
    {
        public Venta Venta { get; set; }
        public NodoVenta Izquierdo { get; set; }
        public NodoVenta Derecho { get; set; }

        public NodoVenta(Venta venta)
        {
            Venta = venta;
            Izquierdo = null;
            Derecho = null;
        }
    }
}
