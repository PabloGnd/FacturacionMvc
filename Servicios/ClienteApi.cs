using Newtonsoft.Json;
using FacturacionMvc.Models;
using FacturacionMvc.Servicios;
using System.Net.Http.Headers;
using System.Text;

namespace FacturacionMvc.Servicios
{
    public class ClienteApi : IClienteApi
    {
        private static string strbaseUrl;
        public ClienteApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<List<ClienteView>> Lista(int intIdEmisor)
        {
            List<ClienteView> lista = new List<ClienteView>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Cliente/ListarTop/{intIdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lista = result.lstClienteView;
                return lista;
            }

            return null;
        }

        public async Task<Cliente> Obtener(int intIdCliente)
        {
            Cliente objeto = new Cliente();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Cliente/Obtener/{intIdCliente}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ClienteResult>(json_respuesta);
                objeto = result.dtoCliente;
                return objeto;
            }

            return null;
        }

        public async Task<bool> Editar(Cliente objeto)
        {

            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Cliente/Editar", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> Eliminar(int intIdCliente)
        {
            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);

            var response = await cliente.GetAsync($"/api/Cliente/Eliminar/{intIdCliente}");


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> Guardar(Cliente objeto)
        {
            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Cliente/Guardar", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        

        public async Task<List<Cliente>> ObtenerIdentificacionApellidoNombre(string strIdentificacion, string strApellido, string strNombre)
        {
            List<Cliente> lista = new List<Cliente>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Cliente/ObtenerIdentificacionApellidoNombre/{strIdentificacion}/{strApellido}/{strNombre}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lista = result.lstCliente;
                return lista;
            }

            return null;
        }

    }
    
}