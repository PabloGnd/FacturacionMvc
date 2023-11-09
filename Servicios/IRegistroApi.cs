using FacturacionMvc.Models;
namespace FacturacionMvc.Servicios

{
    public interface IRegistroApi
    {
        Task<Registro> Guardar(Registro objeto);
        Task<VMUsuarios> Validar(string strNombreUsuario, string strPassword);
        
        
    }

}
