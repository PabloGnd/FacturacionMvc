namespace FacturacionMvc.Models
{
    public class TipoComprobante
    {
        public int IdTipoComprobante { get; set; }

        public int? IdEmisor { get; set; }

        public string? CodigoComprobante { get; set; }

        public string? DescripcionComprobante { get; set; }

        public virtual Emisor? IdEmisorNavigation { get; set; }
    }
}
