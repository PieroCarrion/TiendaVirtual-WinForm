using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
namespace Datos {
    public class dProducto {
        private Database db = null;
        public dProducto() {
            db = new Database();
        }
        public string insertarProducto(eProducto producto) {
            try {
                string insert = string.Format("INSERT INTO tabla_Producto (codigo,nombre,precio,stock) VALUES ('{0}','{1}',{2},{3})", producto.codigoProducto, producto.nombreProducto, producto.precioProducto, producto.stockProducto);
                SqlCommand cmd = new SqlCommand(insert, db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Producto Registrado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public string modificarProducto(eProducto producto, string codigoProducto) {
            try {
                string update = string.Format("UPDATE tabla_Producto SET codigo = '{0}', nombre = '{1}', precio = {2}, stock = {3}  WHERE codigo = {4}", producto.codigoProducto, producto.nombreProducto, producto.precioProducto, producto.stockProducto, codigoProducto);
                SqlCommand cmd = new SqlCommand(update,db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Producto Modificado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public bool actualizarStock(string codigoProducto, int nuevoStock) {
            try {
                string update = string.Format("UPDATE tabla_Producto SET stock = {1}  WHERE codigo = {0}", codigoProducto, nuevoStock);
                SqlCommand cmd = new SqlCommand(update, db.conectaDB());
                cmd.ExecuteNonQuery();
                return true;
            } catch (SqlException ex) {
                return false;
            } finally {
                db.desconectaDB();
            }
        }
        public string eliminarProducto(string codigoProducto) {
            try {
                string delete = string.Format("DELETE FROM tabla_Producto Where codigo = '{0}'", codigoProducto);
                SqlCommand cmd = new SqlCommand(delete,db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Producto Eliminado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public eProducto buscarProductoxCodigo(string codigoProducto) {
            eProducto producto = null;
            try {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT codigo, nombre, precio, stock FROM tabla_Producto WHERE codigo='{0}'",codigoProducto),db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    producto = new eProducto();
                    producto.codigoProducto = (string)reader["codigo"]; 
                    producto.nombreProducto = (string)reader["nombre"];
                    producto.precioProducto = (decimal)reader["precio"];
                    producto.stockProducto = (int)reader["stock"];
                }
                reader.Close();
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
            return producto;
        }
        public eProducto buscarProductoxNombre(string nombreProducto) {
            eProducto producto = null;
            try {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT codigo,nombre,codigo,precio,stock FROM tabla_Producto WHERE nombre='{0}'",nombreProducto),db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    producto = new eProducto();
                    producto.codigoProducto = (string)reader["codigo"];
                    producto.nombreProducto = (string)reader["nombre"];
                    producto.precioProducto = (decimal)reader["precio"];
                    producto.stockProducto = (int)reader["stock"];
                }
                reader.Close();
            } catch (SqlException ex){
                return null;
            } finally {
                db.desconectaDB();
            }
            return producto;
        }
        public List<eProducto> listarProductos() {
            List<eProducto> listaProductos = new List<eProducto>();
            eProducto producto = null;
            try {
                SqlCommand cmd = new SqlCommand("SELECT nombre,codigo,precio,stock FROM tabla_Producto ", db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    producto = new eProducto();
                    producto.codigoProducto = (string)reader["codigo"];
                    producto.nombreProducto = (string)reader["nombre"];
                    producto.precioProducto = (decimal)reader["precio"];
                    producto.stockProducto = (int)reader["stock"];
                    listaProductos.Add(producto);
                }
                reader.Close();
                return listaProductos;
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
        }
    }
}
