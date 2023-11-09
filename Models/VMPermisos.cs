namespace FacturacionMvc.Models
{
    public class VMPermisos
    {
        public int IdPermisos { get; set; }
        public int? IdModulo { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Estado { get; set; }
        public string DescripcionModulo { get; set; }
        public string AccionModulo { get; set; }
        public string ControladorModulo { get; set; }
        public string IconoModulo { get; set; }
    }
}
