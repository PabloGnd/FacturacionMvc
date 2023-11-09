namespace FacturacionMvc.Models
{
    public class Permiso
    {
        public int IdPermisos { get; set; }
        public int? IdModulo { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Estado { get; set; }

        //public virtual Modulo IdModuloNavigation { get; set; }
        //public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
