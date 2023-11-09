namespace FacturacionMvc.Models
{
    public class PermisoResult
    {
        public List<Permiso> lstPermiso { get; set; }
        public Permiso dtoPermiso { get; set; }
        public List<VMPermisos> lstVMPermisosSession { get; set; }
        public List<ClienteView> lstClienteView { get; set; }
        public List<Cliente> lstCliente { get; set; }
        public List<Producto> lstProducto { get; set; }
        public List<Factura> lstFactura { get; set; }
        public List<VMUsuarios> lstVMUsuarios { get; set; }
        public List<VMEstablecimiento> lstVMEstablecimiento { get; set; }  
    }
}
