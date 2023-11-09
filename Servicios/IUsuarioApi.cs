using FacturacionMvc.Models;

namespace FacturacionMvc.Servicios
{
    public interface IUsuarioApi
    {
        Task<List<VMUsuarios>> Lista(int intIdEmisor);
        Task<bool> Editar(Usuario objeto);
        Task<bool> GuardarUsuario(Usuario objeto);
        Task<bool> Eliminar(int intIdCliente);
        Task<bool> EditarPermisos(Permiso objeto);
        Task<List<VMPermisos>> ConsultaPermisos(int IdUsuario);
        Task<VMGuardarPermisos> GuardarPermisos(VMGuardarPermisos objeto);
    }
}
