using Newtonsoft.Json;
using FacturacionMvc.Models;
using FacturacionMvc.Servicios;
using System.Net.Http.Headers;
using System.Text;

namespace FacturacionMvc.Servicios
{
    public class UsuarioApi : IUsuarioApi
    {
        private static string strbaseUrl;
        public UsuarioApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<List<VMUsuarios>> Lista(int intIdEmisor)
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


        public async Task<bool> EditarPermisos(Permiso objeto) { 
            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl); 
            var conten = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Usuario/EditarPermisos", conten);

            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;
            }
            return blnRespuesta;
        }
        public async Task<bool> Editar(Usuario objeto)
        {

            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Usuario/Editar", content);


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> Eliminar(int intIdUsuario)
        {
            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);

            var response = await cliente.GetAsync($"/api/Usuario/Eliminar/{intIdUsuario}");


            if (response.IsSuccessStatusCode)
            {
                blnRespuesta = true;


            }

            return blnRespuesta;
        }

        public async Task<bool> GuardarUsuario(Usuario objeto)
        {
            
            bool blnRespuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Usuario/GuardarUsuario", content);

            if (response.IsSuccessStatusCode)
            {

                blnRespuesta = true;
              


            }
            return blnRespuesta;
        }

        public async Task<List<VMPermisos>> ConsultaPermisos(int IdUsuario)
        {
            List<VMPermisos> lstVMPermiso = new List<VMPermisos>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Usuario/ConsultaPermisos/{IdUsuario}");


            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<VMPermisosResult>(json_respuesta);
                lstVMPermiso = result.lstVMPermisosFor;
                return lstVMPermiso;
            }

            return null;
        }
        public async Task<VMGuardarPermisos> GuardarPermisos(VMGuardarPermisos objeto)
        {
            VMGuardarPermisos dtoVMGuardarPermisos = new VMGuardarPermisos();
            
            
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Usuario/GuardarPermisos", content);


            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<VMGuardarPermisos>(varJsonRespuesta);
                //dtoFactura.CodigoFactura = varResult.CodigoFactura;
                //dtoFactura.MensajeFactura = varResult.MensajeFactura;


            }
            return dtoVMGuardarPermisos;

        }

    }

}