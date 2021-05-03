namespace Entidades {
    public class eVenta {
        public int idVenta { get; set; }
        public string dniCliente { get; set; }
        public int cantidadProductosVenta { get; set; }
        public decimal totalVenta { get; set; }
        public string fechaVenta { get; set; }
        public string destinoVenta { get; set; }
        public eVenta() { }
        public eVenta(string dniCliente, int cantidadProductosVenta, decimal totalVenta, string fechaVenta,string destinoVenta) {
            this.dniCliente = dniCliente;
            this.cantidadProductosVenta = cantidadProductosVenta;
            this.totalVenta = totalVenta;
            this.fechaVenta = fechaVenta;
            this.destinoVenta = destinoVenta;
        }
    }   
}
