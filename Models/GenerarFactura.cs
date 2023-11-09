namespace FacturacionMvc.Models
{
    public class GenerarFactura
    {
        //public Factura dtoFactura { get; set; }
        public List<DetalleFactura> lstDetalleFactura { get; set; }

        public Cliente dtoClientes { get; set; }
        public Sucursal dtoSucursal { get; set; }
        public Establecimiento dtoEstablecimiento { get; set; }
        public Emisor dtoEmisor { get; set; }

        public Factura dtoFactura { get; set; }
        public bool AplicaIva { get; set; }


        public int Codigo { get; set; }
        public string Mensaje { get; set; }

        //public string? strFechaInicio { get; set; }
        //public string? strFechaFin { get; set; }




    }
}
