using Microsoft.AspNetCore.Mvc;
using FacturacionMvc.Servicios;
using FacturacionMvc.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Reflection;

namespace FacturacionMvc.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IRegistroApi registroApi;
        public RegistroController(IRegistroApi registroApi)
        {
            this.registroApi = registroApi;
        }
        public async Task<ActionResult> Registro()
        {
            if (HttpContext.Session.GetInt32("Error") == null)
            {
                HttpContext.Session.SetInt32("Error", 0);
                HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);
                HttpContext.Session.SetString("MensajeError", string.Empty);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(IFormCollection frmRegistro, Emisor dtoR)
        {
            Registro dtoRegistro = new Registro();
            Registro dtoRegistroRespuesta = new Registro();
            dtoRegistro.Emisor = new Emisor();
            dtoRegistro.Establecimiento = new Establecimiento();
            dtoRegistro.Sucursal = new Sucursal();
            dtoRegistro.Usuario = new Usuario();

            dtoRegistro.Emisor.Ruc = frmRegistro["Ruc"].ToString();
            dtoRegistro.Emisor.RazonSocial = frmRegistro["RazonSocial"].ToString();
            dtoRegistro.Emisor.NombreComercial = frmRegistro["NonbreComercial"].ToString();
            dtoRegistro.Emisor.DireccionMatriz = frmRegistro["DireccionNegocio"].ToString();
            dtoRegistro.Emisor.Email = frmRegistro["Email"].ToString();
            dtoRegistro.Emisor.ObligadoContabilidad = frmRegistro["Contabilidad"].ToString();
            dtoRegistro.Emisor.ContribuyenteEspecial = frmRegistro["ContribuyenteEspecial"].ToString();
            dtoRegistro.Establecimiento.CodigoEstablecimiento = frmRegistro["CodigoEstablecimiento"].ToString();
            dtoRegistro.Establecimiento.Descripcion = frmRegistro["NombreEstablecimiento"].ToString();
            dtoRegistro.Establecimiento.Direccion = frmRegistro["DireccionEstablecimiento"].ToString();
            dtoRegistro.Sucursal.CodigoSucursal = frmRegistro["CodigoSucursal"].ToString();
            dtoRegistro.Usuario.NikUsuario = frmRegistro["Nikname"].ToString();
            dtoRegistro.Usuario.Contrasenia = frmRegistro["password"].ToString();

            //using (var ms = new System.IO.MemoryStream())
            //{


            //    await dtoR.ArchivoFile.CopyToAsync(ms);
            //    dtoRegistro.Emisor.Archivo = ms.ToArray();

            //}
            dtoRegistroRespuesta = await registroApi.Guardar(dtoRegistro);
            if (dtoRegistroRespuesta.Codigo == "1")
            {
                return RedirectToAction("Login");
            }
            else
            {
                HttpContext.Session.SetString("MensajeError", dtoRegistroRespuesta.Mensaje);
                HttpContext.Session.SetInt32("Error", 0);
                return RedirectToAction("Registro");
            }




        }
        public async Task<ActionResult> Login()
        {
            if (HttpContext.Session.GetInt32("Error") == null)
            {
                HttpContext.Session.SetInt32("Error", 1);
                HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);
            }

            return View();
        }

        public async Task<ActionResult> Ingreso()
        {
            //List<VMPermisos> lstPermisosSession = new List<VMPermisos>();
            //string lstPermisosString = HttpContext.Session.GetString("lstPermisos");
            //lstPermisosSession = JsonConvert.DeserializeObject<List<VMPermisos>>(lstPermisosString);

            //PermisoResult model = new PermisoResult();
            //model.lstVMPermisosSession = lstPermisosSession;
            if (HttpContext.Session.GetInt32("Error") == null)
            {
                HttpContext.Session.SetInt32("Error", 1);
                HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);
                HttpContext.Session.SetString("Login", string.Empty);
            }
            return View();
            //return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Validar(VMUsuarios dtoUsuario)
        {
            VMUsuarios dtoUsuarioResult = new VMUsuarios();
            List<VMPermisos> lstVMPermisos = new List<VMPermisos>();

            if (!string.IsNullOrEmpty(dtoUsuario.NikUsuario) && !string.IsNullOrEmpty(dtoUsuario.Contrasenia))
            {
                dtoUsuarioResult = await registroApi.Validar(dtoUsuario.NikUsuario, dtoUsuario.Contrasenia);

                if (dtoUsuarioResult == null)
                {
                    HttpContext.Session.SetInt32("Error", 0);
                    HttpContext.Session.SetString("MensajeErrorLogin", "Usuario incorrecto");
                    return RedirectToAction("Login", "Registro");
                }
                else 
                {


                    HttpContext.Session.SetInt32("varIdEmisor", (int)dtoUsuarioResult.IdEmisor);
                    HttpContext.Session.SetInt32("varIdUsuario", (int)dtoUsuarioResult.IdUsuario);
                    HttpContext.Session.SetString("varCodigoSucursal", dtoUsuarioResult.CodigoSucursal);
                    HttpContext.Session.SetString("varCodigoEstablecimiento", dtoUsuarioResult.CodigoEstablecimiento);
                    HttpContext.Session.SetString("varIdNick", dtoUsuarioResult.NikUsuario);
                    HttpContext.Session.SetInt32("varIdSucursal", (int)dtoUsuarioResult.IdSucursal);
                    HttpContext.Session.SetInt32("varIdEstablecimiento", (int)dtoUsuarioResult.IdEstablecimiento);
                    foreach (VMPermisos dtoVMPermisosFor in dtoUsuarioResult.lstVMPermisos)
                    {
                        if (dtoVMPermisosFor.Estado == true)
                        {
                            lstVMPermisos.Add(dtoVMPermisosFor);
                        }
                    }
                    string strVMPermisos = JsonConvert.SerializeObject(dtoUsuarioResult.lstVMPermisos);
                    HttpContext.Session.SetString("lstPermisos", strVMPermisos);


                    return RedirectToAction("Ingreso", "Registro");
                }
                

            }
            else
            {
                return RedirectToAction("Error");
            }

        }



    }
}