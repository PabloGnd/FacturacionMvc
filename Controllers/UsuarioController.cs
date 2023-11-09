using Microsoft.AspNetCore.Mvc;
using FacturacionMvc.Servicios;
using FacturacionMvc.Models;
using Newtonsoft.Json;

namespace FacturacionMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApi usuarioApi;

        public UsuarioController(IUsuarioApi usuarioApi)
        {
            this.usuarioApi = usuarioApi;
        }
        //Vista index de listar los clientes de a base de datos
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        //Obtener el cliente por idCliente
        
        [HttpGet]
        public async Task<IActionResult> Lista(int intIdEmisor)
        {
            PermisoResult dtoPermisoResult = new PermisoResult();
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));


            List<VMUsuarios> lstVMUsuario = await usuarioApi.Lista(intIdEmisor);

            
            return View("Index", lstVMUsuario);

        }
        [HttpPost]
        public async Task<IActionResult> GuardarUsuario(IFormCollection frmUsuario)
        {
            Usuario dtoUsuario = new Usuario();
            if (!string.IsNullOrEmpty(frmUsuario["IdUsuario"].ToString()))
            {
                dtoUsuario.IdUsuario = Convert.ToInt32(frmUsuario["IdUsuario"].ToString());
            }
            dtoUsuario.IdSucursal = HttpContext.Session.GetInt32("varIdSucursal");
            dtoUsuario.NombreUsuario = frmUsuario["Nombre"].ToString();
            dtoUsuario.NikUsuario = frmUsuario["NikUsuario"].ToString();
            dtoUsuario.Contrasenia = frmUsuario["Contrasenia"].ToString();
            dtoUsuario.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");

            bool respuesta;

            if (dtoUsuario.IdUsuario == 0)
            {
                respuesta = await usuarioApi.GuardarUsuario(dtoUsuario);

            }
            else
            {
                respuesta = await usuarioApi.Editar(dtoUsuario);
            }
            if (respuesta)
                return RedirectToAction("Lista", "Usuario");
            else
                return RedirectToAction("Error", "Home");


        }

        [HttpPost]
        public async Task<IActionResult> EditarPermisos(IFormCollection frmPermiso)
        {
            Permiso dtoPermiso = new Permiso();
            //dtoPermiso.Estado = frmPermiso["Estado"].;
            return RedirectToAction("Lista", "Usuario");
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int intIdUsuario)
        {
            var respuesta = await usuarioApi.Eliminar(intIdUsuario);

            if (respuesta)
                return RedirectToAction("Lista", "Usuario");
            else
                return RedirectToAction("Error", "Home");

        }

        public async Task<IActionResult> ConsultaPermisos(int IdUsuario)
        {
            
            Permiso ModeloPermiso = new Permiso();
            List<VMPermisos> lstVMPermiso = await usuarioApi.ConsultaPermisos(IdUsuario);
            if (lstVMPermiso.Count == 0)
            {
                return new JsonResult(Ok(ModeloPermiso));
            }
            return new JsonResult(Ok(lstVMPermiso));


        }

        [HttpPost]
        public async Task<IActionResult> GuardarPermisos( List<Permiso> Permisos)
        {
            //////implementar en cliente el tipo de identificacion para crear cleinte o editar 
            ///

            VMGuardarPermisos dtoVMGuardarPermisos = new VMGuardarPermisos();   
            dtoVMGuardarPermisos.lstPermisos = Permisos;
            VMGuardarPermisos dtoVMGuardarPermisosRespuesta = new VMGuardarPermisos();
            dtoVMGuardarPermisosRespuesta = await usuarioApi.GuardarPermisos(dtoVMGuardarPermisos);

            

            return new JsonResult(Ok(dtoVMGuardarPermisosRespuesta));



        }

    }
}
