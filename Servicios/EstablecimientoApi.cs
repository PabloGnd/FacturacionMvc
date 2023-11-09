using Newtonsoft.Json;
using FacturacionMvc.Models;
using FacturacionMvc.Servicios;
using System.Net.Http.Headers;
using System.Text;

namespace FacturacionMvc.Servicios
{
    public class EstablecimientoApi : IEstablecimientoApi
    {
        private static string strbaseUrl;
        public EstablecimientoApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<List<VMEstablecimiento>> Lista(int intIdEmisor)
        {
            List<VMEstablecimiento> lista = new List<VMEstablecimiento>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Establecimiento/lista/{intIdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PermisoResult>(json_respuesta);
                lista = result.lstVMEstablecimiento;
                return lista;
            }

            return null;
        }
        public async Task<bool> GuardarEstablecimiento(Establecimiento objeto)
        {

            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Establecimiento/GuardarEstablecimiento", content);

            if (response.IsSuccessStatusCode)
            {

                blnRespuesta = true;



            }
            return blnRespuesta;
        }

        public async Task<bool> Editar(Establecimiento objeto)
        {

            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Establecimiento/Editar", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> GuardarSucursal(Sucursal objeto)
        {

            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Establecimiento/GuardarSucursal", content);

            if (response.IsSuccessStatusCode)
            {

                blnRespuesta = true;



            }
            return blnRespuesta;
        }

        public async Task<bool> EditarSucursal(Sucursal objeto)
        {

            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Establecimiento/EditarSucursal", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<List<VMUsuarios>> ListaUsuarios(int intIdEmisor)
        {
            List<VMUsuarios> lista = new List<VMUsuarios>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Usuario/lista/{intIdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<VMUsuariosResult>(json_respuesta);
                lista = result.lstVMUsuarios;
                return lista;
            }

            return null;
        }
    }
}
