using FacturacionMvc.Models;
namespace FacturacionMvc.Servicios
{
    public interface IProductoApi
    {
        Task<List<Producto>> Lista(int IdEmisor);
        Task<Producto> Obtener(int intIdProducto);
        Task<bool> Editar(Producto objeto);
        Task<bool> Guardar(Producto objeto);
        Task<bool> Eliminar(int intIdProducto);
        Task<List<Producto>> ObtenerNemonicoDescripcion(string strNemonico, string strDescripcion);
    }
}
