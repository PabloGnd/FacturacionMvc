namespace FacturacionMvc.Models
{
    public class VMEstablecimiento
    {
        public int IdEstablecimiento { get; set; }

        public int? IdEmisor { get; set; }

        public string? CodigoEstablecimiento { get; set; }

        public string? Descripcion { get; set; }

        public string? Direccion { get; set; }
        public List<VMSucursal> lstVMSucursal { get; set; }
    }
}
