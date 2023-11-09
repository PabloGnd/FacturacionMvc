using FacturacionMvc.Models;

namespace FacturacionMvc.Servicios
{
    public interface IEstablecimientoApi
    {
        Task<List<VMEstablecimiento>> Lista(int intIdEmisor);
        Task<bool> GuardarEstablecimiento(Establecimiento objeto);
        Task<bool> Editar(Establecimiento objeto);
        Task<bool> EditarSucursal(Sucursal objeto);
        Task<bool> GuardarSucursal(Sucursal objeto);

        Task<List<VMUsuarios>> ListaUsuarios(int intIdEmisor);
    }
}