namespace FacturacionMvc.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public int? IdEmisor { get; set; }

        public string? Nemonico { get; set; }

        public string? Descripcion { get; set; }

        public int? Stok { get; set; }

        public decimal? PrecioUnitario { get; set; }

        public decimal? PorcentajeDescuento { get; set; }
        public bool? Estado { get; set; }

        // public virtual ICollection<DetalleFactura> DetalleFacturas { get; } = new List<DetalleFactura>();

        //public virtual Emisor? IdEmisorNavigation { get; set; }
    }
}
