using FacturacionMvc.Models;
namespace FacturacionMvc.Servicios
{
    public interface IClienteApi
    {
        Task<List<ClienteView>> Lista(int intIdEmisor);
        Task<Cliente> Obtener(int intIdCliente);
        Task<bool> Editar(Cliente objeto);
        Task<bool> Guardar(Cliente objeto);
        Task<bool> Eliminar(int intIdCliente);
        
       Task<List<Cliente>> ObtenerIdentificacionApellidoNombre(string strIdentificacion,  string strApellido, string strNombre);
    }
}
