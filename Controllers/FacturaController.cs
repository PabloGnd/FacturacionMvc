using Microsoft.AspNetCore.Mvc;
using FacturacionMvc.Servicios;
using FacturacionMvc.Models;
using Newtonsoft.Json;

namespace FacturacionMvc.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaApi facturaApi;
        public FacturaController(IFacturaApi facturaApi)
        {
            this.facturaApi = facturaApi;
        }

        public async Task<ActionResult> Factura()
        {
           
            
                HttpContext.Session.SetString("CodigoFactura",String.Empty);
                HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);
           
            return View();
        }

       

        public async Task<JsonResult> ObtenerIdentificacionApellidoNombre(string strIdentificacion)
        {
            
            List<Cliente> lstCliente = new List<Cliente>();
            string strNombre = "0";
            string strApellido = "0";
            if (string.IsNullOrEmpty(strIdentificacion))
            {
                strIdentificacion = "0";
            }

            Cliente dtoCliente = new Cliente();
            lstCliente = await facturaApi.ObtenerIdentificacionApellidoNombre(strIdentificacion, strApellido, strNombre);
            if (lstCliente.Count > 0)
            {
                dtoCliente = lstCliente.FirstOrDefault();
            }
            return new JsonResult(Ok(dtoCliente));


        }



        public async Task<IActionResult> ObtenerNemonicoDescripcion(string strDescripcion)
        {
            string strNemonico = "0";
            if (string.IsNullOrEmpty(strDescripcion))
            {
                strDescripcion = "0";
            }


            Producto ModeloProducto = new Producto();
            List<Producto> lstProducto = await facturaApi.ObtenerNemonicoDescripcion(strNemonico, strDescripcion);
            if (lstProducto.Count == 0) {
                return new JsonResult(Ok(ModeloProducto));
            }
            return new JsonResult(Ok(lstProducto));


        }

        [HttpPost]
        public async Task<IActionResult> Guardar(Cliente Cliente, List<DetalleFactura> DetalleFactura, bool AplicaIva )
        {
            //////implementar en cliente el tipo de identificacion para crear cleinte o editar 
            GenerarFactura dtoGenerarFactura = new GenerarFactura();
            Cliente dtoCliente = new Cliente();
            Establecimiento dtoEstablecimiento = new Establecimiento();
            Sucursal dtoSucursal = new Sucursal();
            Emisor dtoEmisor = new Emisor();

            dtoCliente = Cliente;
            if (dtoCliente.TipoIdentificacion == "Cedula")
            {
                dtoCliente.TipoIdentificacion = "05";
            }
            else if (dtoCliente.TipoIdentificacion == "1")
            {
                dtoCliente.TipoIdentificacion = "04";
            }
            else if (dtoCliente.TipoIdentificacion == "2")
            {
                dtoCliente.TipoIdentificacion = "06";
            }
            dtoCliente.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
            dtoEmisor.IdEmisor = (int)HttpContext.Session.GetInt32("varIdEmisor");
            dtoEstablecimiento.IdEstablecimiento = (int)HttpContext.Session.GetInt32("varIdEstablecimiento");
            dtoSucursal.IdSucursal = (int)HttpContext.Session.GetInt32("varIdSucursal");
            dtoEstablecimiento.CodigoEstablecimiento = HttpContext.Session.GetString("varCodigoEstablecimiento");
            dtoSucursal.CodigoSucursal = HttpContext.Session.GetString("varCodigoSucursal");

            dtoGenerarFactura.dtoClientes = dtoCliente;
            dtoGenerarFactura.dtoEmisor = dtoEmisor;
            dtoGenerarFactura.dtoEstablecimiento = dtoEstablecimiento;
            dtoGenerarFactura.dtoSucursal = dtoSucursal;
            dtoGenerarFactura.AplicaIva = AplicaIva;
            
            dtoGenerarFactura.lstDetalleFactura = DetalleFactura;
            GenerarFactura dtoGenerarFacturaRespuesta = new GenerarFactura();

            dtoGenerarFacturaRespuesta = await facturaApi.Guardar(dtoGenerarFactura);
            HttpContext.Session.SetString("MensajeFactura", dtoGenerarFacturaRespuesta.Mensaje);
            HttpContext.Session.SetInt32("CodigoFactura", dtoGenerarFacturaRespuesta.Codigo);


            return new JsonResult(Ok(dtoGenerarFacturaRespuesta));



        }

        public async Task<ActionResult> ConsultaFactura()
        {
            
            List<Factura> lstFactura = await facturaApi.Lista();
            HttpContext.Session.SetString("CodigoFactura", String.Empty);
            HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);
            
            
            return View("ConsultaFactura", lstFactura);
            
        }
        public async Task<IActionResult> ConsultaProducto(int IdFactura)
        {
            
            Producto ModeloProducto = new Producto();

            List<Producto> lstProducto = await facturaApi.ConsultaProducto(IdFactura);
            
            
            if (lstProducto.Count == 0)
            {
                return new JsonResult(Ok(ModeloProducto));
            }
            return new JsonResult(Ok(lstProducto));


        }
       


        public async Task<IActionResult> ObtenerFacturas(IFormCollection frmColeccion)
        {
            string strFechaInicio = frmColeccion["ConsultaDesde"];
            string strFechaFin = frmColeccion["ConsultaHasta"];
           
         
         
            
            List<Factura> lstFactura = await facturaApi.ConsultaFecha(strFechaInicio, strFechaFin);
            return View("ConsultaFactura", lstFactura);

        }



        [HttpPost]
        public async Task<IActionResult> EnviarFactura(Factura Factura)
        {

            GenerarFactura dtoGenerarFactura = new GenerarFactura();
            Cliente dtoCliente = new Cliente();
            Establecimiento dtoEstablecimiento = new Establecimiento();
            Sucursal dtoSucursal = new Sucursal();
            Emisor dtoEmisor = new Emisor();
            Factura dtoFactura = new Factura();

            dtoFactura.IdFactura = Factura.IdFactura;
            dtoFactura.IdEmisor = Factura.IdEmisor;
            dtoFactura.IdCliente = Factura.IdCliente;
            dtoFactura.NumeroFactura = Factura.NumeroFactura;
            dtoFactura.NumeroAutorizacion = Factura.NumeroAutorizacion;
            dtoFactura.FechaAutorizacion = Factura.FechaAutorizacion;
            dtoFactura.Estado = Factura.Estado;
            dtoFactura.TotalDescuento = Factura.TotalDescuento;
            dtoFactura.Total = Factura.Total;
            dtoFactura.ValorIva = Factura.ValorIva;
            dtoFactura.Subtotal = Factura.Subtotal;
            dtoGenerarFactura.dtoFactura = dtoFactura;

            dtoCliente.IdCliente = (int)dtoFactura.IdCliente;
            dtoEmisor.IdEmisor = (int)dtoFactura.IdEmisor;
            dtoEstablecimiento.IdEstablecimiento = (int)HttpContext.Session.GetInt32("varIdEstablecimiento");
            dtoSucursal.IdSucursal = (int)HttpContext.Session.GetInt32("varIdSucursal");
            dtoEstablecimiento.CodigoEstablecimiento = HttpContext.Session.GetString("varCodigoEstablecimiento");
            dtoSucursal.CodigoSucursal = HttpContext.Session.GetString("varCodigoSucursal");
            dtoGenerarFactura.dtoClientes = dtoCliente;
            dtoGenerarFactura.dtoEmisor = dtoEmisor;
            dtoGenerarFactura.dtoEstablecimiento = dtoEstablecimiento;
            dtoGenerarFactura.dtoSucursal = dtoSucursal;
            GenerarFactura dtoGenerarFacturaRespuesta = new GenerarFactura();
            dtoGenerarFacturaRespuesta = await facturaApi.EnviarFactura(dtoGenerarFactura);
            return new JsonResult(Ok(dtoGenerarFacturaRespuesta));

        }

    }
}
