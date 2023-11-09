using Microsoft.AspNetCore.Mvc;
using FacturacionMvc.Servicios;
using FacturacionMvc.Models;
using Newtonsoft.Json;

namespace FacturacionMvc.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoApi productoApi;

        public ProductoController(IProductoApi productoApi)
        {
            this.productoApi = productoApi;
        }
        public async Task<IActionResult> Index(int IdEmisor)
        {
            
            Producto dtoProducto = new Producto();
            IdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            List<Producto> lstProducto = await productoApi.Lista(IdEmisor);

            
            return View("Index", lstProducto);
        }

        public async Task<IActionResult> Producto(int intIdProducto)
        {
            Producto ModeloProducto = new Producto();
            ViewBag.Accion = "Nuevo Producto";
            if (intIdProducto != 0)
            {
                ModeloProducto = await productoApi.Obtener(intIdProducto);
                ViewBag.Accion = "Editar Producto";

            }
            return View(ModeloProducto);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(IFormCollection frmProducto)
        {
            Producto dtoProducto = new Producto();
            if (!string.IsNullOrEmpty(frmProducto["IdProducto"].ToString()))
            {
                dtoProducto.IdProducto = Convert.ToInt32(frmProducto["IdProducto"].ToString());
            }
            dtoProducto.Nemonico = frmProducto["Nemonico"].ToString();
            dtoProducto.Descripcion = frmProducto["Descripcion"].ToString();
            dtoProducto.Stok = Convert.ToInt32(frmProducto["Stok"].ToString());
            dtoProducto.PrecioUnitario = Convert.ToDecimal(frmProducto["PrecioUnitario"].ToString());
            dtoProducto.PorcentajeDescuento = Convert.ToDecimal(frmProducto["PorcentajeDescuento"].ToString());
            dtoProducto.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");




            bool respuesta;

            if (dtoProducto.IdProducto == 0)
            {
                respuesta = await productoApi.Guardar(dtoProducto);

            }
            else
            {   dtoProducto.Nemonico = dtoProducto.Descripcion.Substring(0, 3);
                if (dtoProducto.Stok != 0) {
                    dtoProducto.Estado = false;
                }
                respuesta = await productoApi.Editar(dtoProducto);
            }
            if (respuesta)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Eliminar(int intIdProducto)
        {
            var respuesta = await productoApi.Eliminar(intIdProducto);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error", "Home");

        }

        public async Task<IActionResult> ObtenerNemonicoDescripcion(IFormCollection frmColeccion)
        {
            string strNemonico = frmColeccion["Nemonico"];
            string strDescripcion = frmColeccion["Descripcion"];
            if (string.IsNullOrEmpty(strNemonico))
            {
                strNemonico = "0";
            }
            if (string.IsNullOrEmpty(strDescripcion))
            {
                strDescripcion = "0";
            }

            Producto ModeloProducto = new Producto();
            List<Producto> lstProducto = await productoApi.ObtenerNemonicoDescripcion(strNemonico, strDescripcion);

            return View("Index", lstProducto);


        }

    }
}
