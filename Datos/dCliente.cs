using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
namespace Datos {
    public class dCliente {
        private Database db = null;
        public dCliente() {
            db = new Database();
        }
        public string insertarCliente(eCliente cliente) {
            try {
                string insert = string.Format("INSERT INTO tabla_Clientes (dni,nombre,contraseña,direccion,telefono,tipo) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", cliente.dniCliente, cliente.nombreCliente, cliente.constraseñaCliente, cliente.direccionCliente, cliente.telefonoCliente, cliente.tipoCliente);
                SqlCommand cmd = new SqlCommand(insert,db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Cliente Registrado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public string modificarCliente(eCliente cliente, string dnicliente) {
            try {
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE tabla_Clientes SET dni ='{0}', nombre = '{1}', contraseña = '{2}', direccion = '{3}', telefono ='{4}' WHERE dni = '{5}' ", cliente.dniCliente, cliente.nombreCliente, cliente.constraseñaCliente, cliente.direccionCliente, cliente.telefonoCliente, dnicliente), db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Cliente Modificado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public string actualizarTipoCliente(string dniCliente, string nTipo) {
            try {
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE tabla_Clientes SET tipo = '{0}' WHERE dni = '{1}' ", nTipo,dniCliente), db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Actualizado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public string eliminarCliente(string dniCliente) {
            try {
                SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM tabla_Clientes WHERE dni = '{0}'", dniCliente),db.conectaDB());
                cmd.ExecuteNonQuery();
                return "Cliente Eliminado";
            } catch (SqlException ex) {
                return ex.Message;
            } finally {
                db.desconectaDB();
            }
        }
        public eCliente buscarCliente(string dni) {
            eCliente aux = null;
            try {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT dni, nombre, telefono, direccion, contraseña, tipo FROM tabla_Clientes WHERE dni='{0}'", dni), db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    aux = new eCliente();
                    aux.dniCliente = (string)reader["dni"];
                    aux.nombreCliente= (string)reader["nombre"];
                    aux.telefonoCliente = (string)reader["telefono"];
                    aux.direccionCliente = (string)reader["direccion"];
                    aux.constraseñaCliente = (string)reader["contraseña"];
                    aux.tipoCliente = (string)reader["tipo"];
                }
                reader.Close();
                return aux;
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
        }
        public List<eCliente> listarClientes() {
            List<eCliente> listaCliente = new List<eCliente>();
            eCliente aux = null;
            try {
                SqlCommand cmd = new SqlCommand("SELECT dni, nombre, telefono, direccion, contraseña, tipo FROM tabla_Clientes ", db.conectaDB());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    aux = new eCliente();
                    aux.dniCliente = (string)reader["dni"];
                    aux.nombreCliente = (string)reader["nombre"];
                    aux.telefonoCliente = (string)reader["telefono"];
                    aux.direccionCliente = (string)reader["direccion"];
                    aux.constraseñaCliente = (string)reader["contraseña"];
                    aux.tipoCliente = (string)reader["tipo"];
                    
                    listaCliente.Add(aux);
                }
                reader.Close();
            } catch (SqlException ex) {
                return null;
            } finally {
                db.desconectaDB();
            }
            return listaCliente;
        }
    }
}
