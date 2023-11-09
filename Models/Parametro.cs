namespace FacturacionMvc.Models
{
    public class Parametro
    {
        public int IdParametro { get; set; }

        public string? Descripcion { get; set; }

        //public virtual ICollection<DetalleParametro> DetalleParametros { get; } = new List<DetalleParametro>();
    }
}
