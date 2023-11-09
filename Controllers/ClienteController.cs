using Microsoft.AspNetCore.Mvc;
using FacturacionMvc.Servicios;
using FacturacionMvc.Models;
using Newtonsoft.Json;

namespace FacturacionMvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteApi clienteApi;

        public ClienteController(IClienteApi clienteApi)
        {
            this.clienteApi = clienteApi;
        }
        //Vista index de listar los clientes de a base de datos
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        //Obtener el cliente por idCliente
        /// <summary>
        /// obtener un cliente por el IdCliente
        /// </summary>
        /// <param name="intIdCliente">  IdCliente de la tabla cliente   </param>
        /// <returns> objeto con los datos del cliente </returns>
        public async Task<IActionResult> Cliente(int intIdCliente)
        {
            Cliente ModeloCliente = new Cliente();
            ViewBag.Accion = "Nuevo Cliente";
            if (intIdCliente != 0)
            {
                ModeloCliente = await clienteApi.Obtener(intIdCliente);
                ViewBag.Accion = "Editar Cliente";

            }
            return View(ModeloCliente);
        }
        [HttpGet]
        public async Task<IActionResult> Lista(int intIdEmisor)
        {
            PermisoResult dtoPermisoResult = new PermisoResult();
            Cliente dtoCliente = new Cliente();
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));


            List<ClienteView> lstCliente = await clienteApi.Lista(intIdEmisor);

            return View("Index", lstCliente);

        }
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(IFormCollection frmCliente)
        {
            Cliente dtoCliente = new Cliente();
            if (!string.IsNullOrEmpty(frmCliente["IdCliente"].ToString()))
            {
                dtoCliente.IdCliente = Convert.ToInt32(frmCliente["IdCliente"].ToString());
            }

            dtoCliente.Identificacion = frmCliente["Identificacion"].ToString();
            dtoCliente.Apellido1 = frmCliente["Apellido"].ToString();
            dtoCliente.Nombre1 = frmCliente["Nombre"].ToString();
            dtoCliente.TipoIdentificacion = frmCliente["TipoIdentificacion"].ToString();
            if (dtoCliente.TipoIdentificacion == "Cedula")
            {
                dtoCliente.TipoIdentificacion = "05";
            }
            else if (dtoCliente.TipoIdentificacion == "1")
            {
                dtoCliente.TipoIdentificacion = "04";
            }
            else if (dtoCliente.TipoIdentificacion == "2") {
                dtoCliente.TipoIdentificacion = "06";
            }
            dtoCliente.DireccionCliente = frmCliente["Direccion"].ToString();
            dtoCliente.Correo = frmCliente["Correo"].ToString();
            dtoCliente.Telefono = frmCliente["Telefono"].ToString();
            dtoCliente.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");



            bool respuesta;

            if (dtoCliente.IdCliente == 0)
            {
                respuesta = await clienteApi.Guardar(dtoCliente);

            }
            else
            {
                respuesta = await clienteApi.Editar(dtoCliente);
            }
            if (respuesta)
                return RedirectToAction("Lista", "Cliente");
            else
                return RedirectToAction("Error", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int intIdCliente)
        {
            var respuesta = await clienteApi.Eliminar(intIdCliente);

            if (respuesta)
                return RedirectToAction("Lista", "Cliente");
            else
                return RedirectToAction("Error", "Home");

        }
      
        public async Task<IActionResult> ObtenerIdentificacionApellidoNombre(IFormCollection frmColeccion)
        {
            string strIdentificacion = frmColeccion["Identificacion"];
            string strNombre = frmColeccion["Nombre"];
            string strApellido = frmColeccion["Apellido"];
            if (string.IsNullOrEmpty(strIdentificacion))
            {
                strIdentificacion = "0";
            }
            if (string.IsNullOrEmpty(strApellido))
            {
                strApellido = "0";
            }
            if (string.IsNullOrEmpty(strNombre))
            {
                strNombre = "0";
            }
            Cliente ModeloCliente = new Cliente();
            List<Cliente> lstCliente = await clienteApi.ObtenerIdentificacionApellidoNombre(strIdentificacion, strApellido, strNombre);

            return View("Index", lstCliente);


        }


    }
}
