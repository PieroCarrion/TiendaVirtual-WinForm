using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
namespace Datos {
    public class dDetalleVenta {
        private Database db = null;
        public dDetalleVenta() {
            db = new Database();
        }
        private bool insertarDetalleVenta(eDetalleVenta objDetalle, int numero) {
            try {
                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO tabla_DetalleVenta (idVenta,codigoProducto,cantidad,pUnitario,total) VALUES ({0},'{1}',{2},{3},{4})",numero,objDetalle.codigoProducto,objDetalle.cantidad,objDetalle.PUnitario, (objDetalle.cantidad * objDetalle.PUnitario)), db.conectaDB());
                cmd.ExecuteNonQuery();
                return true;
            } catch (SqlException ex) {
                return false;
            } finally {
                db.desconectaDB();
            }
        }
        public bool registrarVenta(List<eDetalleVenta> objLista,int numero) {
            bool flag = true;
            dVenta objVenta = new dVenta();
            foreach (eDetalleVenta value in objLista) {
                if (insertarDetalleVenta(value, numero)) {
                    flag = true;
                } else {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public List<eDetalleVenta> buscarDetallesVentaxVenta(int idVenta) {
            List<eDetalleVenta> listaDetalles = new List<eDetalleVenta>();
            eDetalleVenta aux = null;
            try {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT idVenta,codigoProducto,cantidad,pUnitario,total FROM tabla_DetalleVenta WHERE idVenta = {0}", idVenta), db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    aux = new eDetalleVenta();
                    aux.idVenta = (int)reader["idVenta"];
                    aux.codigoProducto= (string)reader["codigoProducto"];
                    aux.cantidad = (int)reader["cantidad"];
                    aux.PUnitario= (decimal)reader["pUnitario"];
                    aux.total = (int)reader["total"];
                    listaDetalles.Add(aux);
                }
                reader.Close();
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
            return listaDetalles;
        }
        public bool modificarDetalleVenta(int nuevaCantidad, int idVenta, string codigoProducto) {
            try {
                string update = string.Format("UPDATE tabla_DetalleVenta SET cantidad = {0} WHERE idVenta = {1} AND codigoProducto = '{2}'", nuevaCantidad, idVenta,codigoProducto);
                SqlCommand cmd = new SqlCommand(update, db.conectaDB());
                cmd.ExecuteNonQuery();
                return true;
            } catch (SqlException ex) {
                return false;
            } finally {
                db.desconectaDB();
            }
        }
        public List<eDetalleVenta> listarDetalles() {
            List<eDetalleVenta> lista = new List<eDetalleVenta>();
            eDetalleVenta detalle = null;
            try {
                SqlCommand cmd = new SqlCommand("SELECT idVenta, codigoProducto, cantidad, pUnitario FROM tabla_DetalleVenta",db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    detalle = new eDetalleVenta();
                    detalle.idVenta = (int)reader["idVenta"];
                    detalle.codigoProducto = (string)reader["codigoProducto"];
                    detalle.cantidad = (int)reader["cantidad"];
                    detalle.PUnitario = (decimal)reader["pUnitario"];
                    lista.Add(detalle);
                }
                reader.Close();
                return lista;
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
        }
    }
}
