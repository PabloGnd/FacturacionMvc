using Microsoft.AspNetCore.Mvc;
using FacturacionMvc.Servicios;
using FacturacionMvc.Models;
using Newtonsoft.Json;

namespace FacturacionMvc.Controllers
{
    public class EstablecimientoController : Controller
    {

        private readonly IEstablecimientoApi estableciemientoApi;

        public EstablecimientoController(IEstablecimientoApi estableciemientoApi)
        {
            this.estableciemientoApi = estableciemientoApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista(int intIdEmisor)
        {
            
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));


            List<VMEstablecimiento> lstVMEstablecimiento = await estableciemientoApi.Lista(intIdEmisor);


            return View("Index", lstVMEstablecimiento);

        }
        [HttpPost]
        public async Task<IActionResult> GuardarEstablecimiento(IFormCollection frmEstablecimiento)
        {
            Establecimiento dtoEstablecimiento = new Establecimiento();
            if (!string.IsNullOrEmpty(frmEstablecimiento["IdEstablecimiento"].ToString()))
            {
                dtoEstablecimiento.IdEstablecimiento = Convert.ToInt32(frmEstablecimiento["IdEstablecimiento"].ToString());
            }
            dtoEstablecimiento.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
            dtoEstablecimiento.Descripcion = frmEstablecimiento["Descripcion"].ToString();
            dtoEstablecimiento.Direccion = frmEstablecimiento["Direccion"].ToString();
            dtoEstablecimiento.CodigoEstablecimiento = frmEstablecimiento["CodigoEstablecimiento"].ToString();


            bool respuesta;

            if (dtoEstablecimiento.IdEstablecimiento == 0)
            {
                respuesta = await estableciemientoApi.GuardarEstablecimiento(dtoEstablecimiento);

            }
            else
            {
                respuesta = await estableciemientoApi.Editar(dtoEstablecimiento);
            }
            if (respuesta)
                return RedirectToAction("Lista", "Establecimiento");
            else
                return RedirectToAction("Error", "Home");


        }


        [HttpPost]
        public async Task<IActionResult> GuardarSucursal(IFormCollection frmSucursal)
        {
            Sucursal dtoSucursal = new Sucursal();
            if (!string.IsNullOrEmpty(frmSucursal["IdSucursal"].ToString()))
            {
                dtoSucursal.IdSucursal = Convert.ToInt32(frmSucursal["IdSucursal"].ToString());
            }
            dtoSucursal.IdEstablecimiento = Convert.ToInt32(frmSucursal["IdEstablecimiento"].ToString());
            dtoSucursal.CodigoSucursal = frmSucursal["CodigoSucursal"].ToString();


            bool respuesta;

            if (dtoSucursal.IdSucursal == 0)
            {
                respuesta = await estableciemientoApi.GuardarSucursal(dtoSucursal);

            }
            else
            {
                respuesta = await estableciemientoApi.EditarSucursal(dtoSucursal);
            }
            if (respuesta)
                return RedirectToAction("Lista", "Establecimiento");
            else
                return RedirectToAction("Error", "Home");


        }

        [HttpPost]
        public async Task<IActionResult> ListaUsuarios(int intIdEmisor)
        {
            VMUsuarios dtoVMUsuarios = new VMUsuarios();    
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));


            List<VMUsuarios> lstVMUsuario = await estableciemientoApi.ListaUsuarios(intIdEmisor);


            if (lstVMUsuario.Count == 0)
            {
                return new JsonResult(Ok(dtoVMUsuarios));
            }
            return new JsonResult(Ok(lstVMUsuario));
            
            
        }
    }
}
