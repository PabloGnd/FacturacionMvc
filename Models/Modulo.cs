namespace FacturacionMvc.Models
{
    public class Modulo
    {
        public int IdModulo { get; set; }
        public int? IdPadreModulo { get; set; }
        public int? IdEmisor { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string UrlModulo { get; set; }

        //public virtual Emisor IdEmisorNavigation { get; set; }
        //public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
