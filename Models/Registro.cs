namespace FacturacionMvc.Models
{
    public class Registro
    {
        public Emisor Emisor { get; set; }
        public Establecimiento Establecimiento { get; set; }
        public Sucursal Sucursal { get; set; }
        public Usuario Usuario { get; set; }

        public string Codigo { get; set; }

        public string Mensaje { get; set; }
        public List<Usuario> lstUsuario { get; set; }
        public Usuario dtoRegistro { get; set; }

        
    }
}
