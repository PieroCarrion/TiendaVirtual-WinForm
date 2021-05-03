using System.Collections.Generic;
using Datos;
using Entidades;
namespace Negocio {
    public class nCliente {
        dCliente dCliente;
        public nCliente() {
            dCliente = new dCliente();
        }
        public string registrarCliente(string nombreCliente,string dniCliente, string contraseñaCliente, string direccionCliente, string telefonoCliente) {
            eCliente cliente = null;
            
            if (dCliente.buscarCliente(dniCliente) == null) {
                if (nombreCliente[0] == 'x' || nombreCliente[0] == 'X') {
                    cliente = new eCliente(nombreCliente, dniCliente, contraseñaCliente, direccionCliente, telefonoCliente, "Administrador");
                    dCliente.insertarCliente(cliente);
                    return "Administrador Registrado";
                } else {
                    cliente = new eCliente(nombreCliente, dniCliente, contraseñaCliente, direccionCliente, telefonoCliente, "No Premium");
                    return dCliente.insertarCliente(cliente);
                }
            } else {
                return "El cliente ya existe";
            }
        }
        public string modificarCliente(string _nombreCliente, string _dniCliente, string _contraseñaCliente, string _direccionCliente, string _telefonoCliente, string dni, string tipoCliente) {
            eCliente cliente = new eCliente(_nombreCliente, _dniCliente, _contraseñaCliente, _direccionCliente, _telefonoCliente,tipoCliente);
            if (dCliente.buscarCliente(dni) != null) {
                return dCliente.modificarCliente(cliente,dni);
            } else {
                return "El cliente no existe";
            }
        }
        public void actualizarCliente(string dniCliente, string nTipo) {
            dCliente.actualizarTipoCliente(dniCliente, nTipo);
        }
        public string eliminarCliente(string dniCliente) {
            if (dCliente.buscarCliente(dniCliente) != null) {
                return dCliente.eliminarCliente(dniCliente);
            } else {
                return "El cliente no existe";
            }
        }
        public eCliente buscarCliente(string dni) {
            return dCliente.buscarCliente(dni);
        }
        public List<eCliente> listarClientes() {
            return dCliente.listarClientes();
        }
        public bool existeCliente(string dni) {
            if (buscarCliente(dni)!=null) {
                return true;
            }else {
                return false;
            }
        }
    }
}
