using Newtonsoft.Json;
using FacturacionMvc.Models;
using FacturacionMvc.Servicios;
using System.Net.Http.Headers;
using System.Text;

namespace FacturacionMvc.Servicios
{
    public class ProductoApi : IProductoApi
    {
        private static string strbaseUrl;

        public ProductoApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Producto>> Lista(int IdEmisor)
        {
            List<Producto> lstProducto = new List<Producto>();
            var producto = new HttpClient();
            producto.BaseAddress = new Uri(strbaseUrl);
            var response = await producto.GetAsync($"/api/Producto/lista/{IdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lstProducto = result.lstProducto;
                return lstProducto;
            }

            return null;
        }
        public async Task<Producto> Obtener(int intIdProducto)
        {
            Producto objeto = new Producto();
            var producto = new HttpClient();
            producto.BaseAddress = new Uri(strbaseUrl);
            var response = await producto.GetAsync($"/api/Producto/Obtener/{intIdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ClienteResult>(json_respuesta);
                //objeto = result.dtoCliente;
                return objeto;
            }

            return null;
        }

        public async Task<bool> Editar(Producto objeto)
        {

            bool blnRespuesta = false;
            var producto = new HttpClient();
            producto.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await producto.PostAsync($"/api/Producto/Editar", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> Eliminar(int intIdProducto)
        {
            bool blnRespuesta = false;
            var producto = new HttpClient();
            producto.BaseAddress = new Uri(strbaseUrl);

            var response = await producto.GetAsync($"/api/Producto/Eliminar/{intIdProducto}");


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> Guardar(Producto objeto)
        {
            bool blnRespuesta = false;
            var producto = new HttpClient();
            producto.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await producto.PostAsync($"/api/Producto/Guardar", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
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
    }


}
