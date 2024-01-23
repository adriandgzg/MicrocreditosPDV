using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class ApiService
    {
        HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
        }

        public async Task<CE_LoginUserResp> LoginPassword(CE_LoginUser pUser)
        {
            CE_LoginUserResp? result = null;

            var uri = new Uri(string.Format(Configuration.URL_LOGIN_PASSWORD));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(uri, httpcontent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<CE_LoginUserResp>(content);
                   
                    return result;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = new CE_LoginUserResp() { message = "Usuario y/o contraseña incorrectos.", issuccess = false };
                }

            }
            catch (Exception ex)
            {
                 result = new CE_LoginUserResp() { message = "Usuario y/o contraseña incorrectos.", issuccess = false };
            }


            return result;
        }
    }
}
