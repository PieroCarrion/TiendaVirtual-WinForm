namespace Entidades {
    public class eProducto {
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public decimal precioProducto { get; set; }
        public int stockProducto { get; set; }
        public int cantidadCompra { get; set; }
        public eProducto() { }
        public eProducto(string nombreProducto, string codigoProducto, decimal precioProducto, int stockProducto) {
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
            this.precioProducto = precioProducto;
            this.stockProducto = stockProducto;
        }
    }
}
