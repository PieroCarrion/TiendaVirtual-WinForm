using System.Collections.Generic;
using Entidades;
using Datos;
namespace Negocio {
    public class nDetalleVenta {
        private dDetalleVenta dDetalleVenta = null;
        public nDetalleVenta() {
            dDetalleVenta = new dDetalleVenta();
        }
        public string registrarVenta(List<eDetalleVenta> objLista, int numero) {
            if (dDetalleVenta.registrarVenta(objLista, numero)) {
                return "Venta Registrada";
            } else {
                return "Error, vuelva a intentarlo";
            }
        }
        public List<eDetalleVenta> buscarVenta(int idVenta) {
            return dDetalleVenta.buscarDetallesVentaxVenta(idVenta);
        }
        public List<eDetalleVenta> listarDetalles() {
            return dDetalleVenta.listarDetalles();
        }
        public string modificarDetalleVenta(int nuevaCantidad, int idVenta, string codigoProducto) {
            if (dDetalleVenta.modificarDetalleVenta(nuevaCantidad, idVenta, codigoProducto)){
                return "Detalle Modificado";
            } else {
                return "Error, vuelva a intentarlo";
            }
        }

    }
}
