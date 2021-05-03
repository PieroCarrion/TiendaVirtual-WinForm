namespace Entidades {
    public class eCliente {
        public string nombreCliente { get; set; }
        public string dniCliente { get; set; }
        public string constraseñaCliente { get; set; }
        public string direccionCliente { get; set; }
        public string telefonoCliente { get; set; }
        public string tipoCliente { get; set; }
        public override string ToString() {
            return "Cliente: " + nombreCliente + ", DNI: " + dniCliente; 
        }
        public eCliente() { }
        public eCliente(string nombreCliente, string dniCliente, string constraseñaCliente, string direccionCliente, string telefonoCliente, string tipoCliente) {
            this.nombreCliente = nombreCliente;
            this.dniCliente = dniCliente;
            this.constraseñaCliente = constraseñaCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
            this.tipoCliente = tipoCliente;
        }
    }
}
