using Newtonsoft.Json;
using FacturacionMvc.Models;
using FacturacionMvc.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace FacturacionMvc.Servicios
{
    public class RegistroApi : IRegistroApi
    {
        private static string strbaseUrl;
        public RegistroApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<Registro> Guardar(Registro objeto)
        {

            Registro dtoRegistro = new Registro();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Registro/Guardar", content);


            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<Registro>(varJsonRespuesta);
                dtoRegistro.Codigo = varResult.Codigo;
                dtoRegistro.Mensaje = varResult.Mensaje;





            }
            return dtoRegistro;

        }

        public async Task<VMUsuarios> Validar(string strNombreUsuario, string strPassword)
        {
            VMUsuarios dtoVMUsuarios = new VMUsuarios();

            var varCliente = new HttpClient();
            varCliente.BaseAddress = new Uri(strbaseUrl);
            var response = await varCliente.GetAsync($"/Api/Registro/Validar/{strNombreUsuario}/{strPassword}");
            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<VMUsuariosResult>(varJsonRespuesta);

                dtoVMUsuarios = varResult.dtoVMUsuarios;
                //dtoVMUsuarios.Codigo = varResult.Codigo;
                //dtoVMUsuarios.Mensaje = varResult.Mensaje;


                return dtoVMUsuarios;
            }
            return null;
        }
    }
}