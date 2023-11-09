using FacturacionMvc.Models;
namespace FacturacionMvc.Servicios   
{
    public interface IFacturaApi
    {
        Task<List<Cliente>> ObtenerIdentificacionApellidoNombre(string strIdentificacion, string strApellido, string strNombre);
        Task<List<Cliente>> ListarTop();
        Task<List<Factura>> Lista();
        Task<List<Producto>> ObtenerNemonicoDescripcion(string strNemonico, string strDescripcion);
        Task<GenerarFactura> Guardar(GenerarFactura objeto);
        Task<GenerarFactura> EnviarFactura(GenerarFactura objeto);
        Task<List<Producto>> ConsultaProducto(int IdFactura);

        Task<List<Factura>> ConsultaFecha(string strFechaInicio, string strFechaFin);
        //Task<GenerarFactura> Guardar(GenerarFactura objeto);
        //Task<Cliente> ObtenerIdentificacion(string strIdentificacion);
    }

}
