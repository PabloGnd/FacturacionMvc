using Newtonsoft.Json;
using FacturacionMvc.Models;
using FacturacionMvc.Servicios;
using System.Net.Http.Headers;
using System.Text;

namespace FacturacionMvc.Servicios
{
    public class FacturaApi : IFacturaApi
    {
        private static string strbaseUrl;
        public FacturaApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Cliente>> ListarTop()
        {
            List<Cliente> lista = new List<Cliente>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync("/api/Cliente/listarTop");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lista = result.lstCliente;
                return lista;
            }

            return null;
        }
        public async Task<List<Cliente>> ObtenerIdentificacionApellidoNombre(string strIdentificacion, string strApellido, string strNombre)
        {
            Cliente dtoCliente = new Cliente();
            List<Cliente> lstCliente = new List<Cliente>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Cliente/ObtenerIdentificacionApellidoNombre/{strIdentificacion}/{strApellido}/{strNombre}");
            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lstCliente = result.lstCliente;

                return lstCliente;
            }

            return null;
        }

        public async Task<List<Factura>> Lista()
        {
            List<Factura> lstFactura = new List<Factura>();
            var factura = new HttpClient();
            factura.BaseAddress = new Uri(strbaseUrl);
            var response = await factura.GetAsync("/api/Factura/lista");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FacturaResult>(json_respuesta);
                lstFactura = result.lstFactura;
                return lstFactura;
            }
            return null;
        }

        public async Task<List<Producto>> ObtenerNemonicoDescripcion(string strNemonico, string strDescripcion)
        {
            List<Producto> lstProducto = new List<Producto>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Producto/ObtenerNemonicoDescripcion/{strNemonico}/{strDescripcion}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lstProducto = result.lstProducto;
                return lstProducto;
            }
            return null;
        }

        public async Task<List<Factura>> ConsultaFecha(string strFechaInicio, string strFechaFin)
        {
            List<Factura> lstFactura = new List<Factura>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Factura/ConsultaFecha/{strFechaInicio}/{strFechaFin}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FacturaResult>(json_respuesta);
                lstFactura = result.lstFactura;
                return lstFactura;
            }
            return null;
        }
        public async Task<GenerarFactura> Guardar(GenerarFactura objeto)
        {
            GenerarFactura dtoFactura = new GenerarFactura();
            Cliente dtoPrueba = new Cliente();
            GenerarFactura dtoFacturaResult = new GenerarFactura();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Factura/Guardar", content);


            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<GenerarFactura>(varJsonRespuesta);
                dtoFactura.Codigo = varResult.Codigo;
                dtoFactura.Mensaje = varResult.Mensaje;


            }
            return dtoFactura;

        }

        public async Task<List<Producto>> ConsultaProducto(int IdProducto)
        {
            List<Producto> lstProducto = new List<Producto>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Factura/ConsultaProducto/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lstProducto = result.lstProducto;
                return lstProducto;
            }
            return null;
        }

        public async Task<GenerarFactura> EnviarFactura(GenerarFactura objeto)
        {
            GenerarFactura dtoFactura = new GenerarFactura();
            Cliente dtoPrueba = new Cliente();
            GenerarFactura dtoFacturaResult = new GenerarFactura();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Factura/EnviarFactura", content);


            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<GenerarFactura>(varJsonRespuesta);
                dtoFactura.Codigo = varResult.Codigo;
                dtoFactura.Mensaje = varResult.Mensaje;


            }
            return dtoFactura;

        }

    }


}