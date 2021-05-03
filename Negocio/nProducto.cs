using System.Collections.Generic;
using Entidades;
using Datos;
namespace Negocio {
    public class nProducto {
        private dProducto dProducto = null;
        public nProducto() {
            dProducto = new dProducto();
        }
        public string registrarProducto(string nombreProducto, string codigoProducto, decimal precio, int stockProducto) {
            if (dProducto.buscarProductoxCodigo(codigoProducto) == null) {
                if (dProducto.buscarProductoxNombre(nombreProducto) == null) {
                    eProducto producto = new eProducto(nombreProducto, codigoProducto, precio, stockProducto);
                    return dProducto.insertarProducto(producto);
                } else {
                    return "Ya existe un producto con el mismo nombre";
                }
            } else {
                return "Ya existe un producto con el mismo codigo";
            }
        }
        public string modificarProducto(string _nombreProducto, string _codigoProducto, decimal _precio, int _stockProducto, string codigoProducto) {
            if (dProducto.buscarProductoxCodigo(codigoProducto) != null) {
                eProducto producto = new eProducto(_nombreProducto, _codigoProducto, _precio, _stockProducto);
                return dProducto.modificarProducto(producto, codigoProducto);
            } else {
                return "No existe un producto con el codigo: " + codigoProducto;
            }
        }
        public bool actualizarStock(string codigoProducto, int nuevoStock) {
            return dProducto.actualizarStock(codigoProducto, nuevoStock);
        }
        public string eliminarProducto(string codigoProducto) {
            return dProducto.eliminarProducto(codigoProducto);
        }
        public eProducto buscarProductoxCodigo(string codigoProducto) {
            return dProducto.buscarProductoxCodigo(codigoProducto);
        }
        public eProducto buscarProductoxNombre(string nombreProducto) {
            return dProducto.buscarProductoxNombre(nombreProducto);
        }
        public List<eProducto> listarProductos() {
            return dProducto.listarProductos();
        }
    }
}
