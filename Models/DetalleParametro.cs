namespace FacturacionMvc.Models
{
    public class DetalleParametro
    {
        public int IdDetalleParametro { get; set; }

        public int? IdParametro { get; set; }

        public string? Nemonico { get; set; }

        public string? Descripcion { get; set; }

        public string? Valor { get; set; }

       // public virtual Parametro? IdParametroNavigation { get; set; }
    }
}
