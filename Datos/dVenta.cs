using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
namespace Datos {
    public class dVenta {
        private Database db = null;
        public dVenta() {
            db = new Database();
        }
        public bool insertarVenta(eVenta objVenta) {
            try {
                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO tabla_Ventas (dniCliente,cantidadProductos,total,fecha,destinoVenta) VALUES ('{0}',{1},{2},'{3}','{4}')", objVenta.dniCliente,objVenta.cantidadProductosVenta,objVenta.totalVenta,objVenta.fechaVenta,objVenta.destinoVenta),db.conectaDB());
                cmd.ExecuteNonQuery();
                return true; 
            } catch (SqlException ex) {
                return false;
            } finally {
                db.desconectaDB();
            }
        }
        public eVenta buscarVenta(int idVenta) {
            eVenta venta = null;
            try {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT idVenta,dniCliente,cantidadProductos,total,fecha,destinoVenta FROM tabla_Ventas WHERE idVenta = {0}", idVenta), db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    venta = new eVenta();
                    venta.idVenta = (int)reader["idVenta"];
                    venta.dniCliente = (string)reader["dniCliente"];
                    venta.cantidadProductosVenta = (int)reader["cantidadProductos"];
                    venta.totalVenta = (decimal)reader["total"];
                    venta.fechaVenta = (string)reader["fecha"];
                    venta.destinoVenta = (string)reader["destinoVenta"];
                }
            } catch (Exception ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
            return venta; 
        }
        public List<eVenta> listarVentas() {
            List<eVenta> listaVentas = new List<eVenta>();
            eVenta venta = null;
            try {
                SqlCommand cmd = new SqlCommand("SELECT idVenta,dniCliente,cantidadProductos,total,fecha,destinoVenta FROM tabla_Ventas", db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    venta = new eVenta();
                    venta.idVenta = (int)reader["idVenta"];
                    venta.dniCliente = (string)reader["dniCliente"];
                    venta.cantidadProductosVenta = (int)reader["cantidadProductos"];
                    venta.totalVenta = (decimal)reader["total"];
                    venta.fechaVenta = (string)reader["fecha"];
                    venta.destinoVenta = (string)reader["destinoVenta"];
                    listaVentas.Add(venta);
                }
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
            return listaVentas;
        }
    }
}
