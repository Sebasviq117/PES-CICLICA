using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Entidades.Response;

namespace Frontend.Servicios
{
    public class LoginService : IngresarUsuarioService
    {
        public async Task<ResLoginUsuario> Login(string UserCorreo, string UserContraseña)
        {
            var loginApi = new List<ResLoginUsuario>();
            var client = new HttpClient();

            string url = "https://webapiciclica.azurewebsites.net/api/usuario/loginUsuario" + UserCorreo + "/" + UserContraseña;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                loginApi = JsonConvert.DeserializeObject<List<ResLoginUsuario>>(content);
                return await Task.FromResult(loginApi.FirstOrDefault());
            }
            else 
            {
                return null;
            }
        }
    }
}
