using Capa_Entidad;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Capa_de_datos
{
    public class CD_LoginUser
    {
        HttpClient _client;
        public CD_LoginUser()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
        }

        public async Task<CE_LoginUserResp> LoginPassword(CE_LoginUser pUser)
        {

            CE_LoginUserResp result = null;

            var uri = new Uri(string.Format(Configuration.URL_LOGIN_PASSWORD));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpCLient = new HttpClient())
                {
                    string? content;
                    var response = await httpCLient.PostAsync(uri, httpcontent);
                    content = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<CE_LoginUserResp>(content?.ToString());
                }

            }
            catch (Exception ex)
            {
                result = new CE_LoginUserResp() { message = "Error.", issuccess = false };
            }


            return result;

        }

        public async Task<CE_LoginUserResp> RefreshToken(CE_RefreshToken pUser)
        {

            CE_LoginUserResp result = null;

            var uri = new Uri(string.Format(Configuration.URL_REFRESH_TOKEN));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpCLient = new HttpClient())
                {
                    string? content;
                    var response = await httpCLient.PostAsync(uri, httpcontent);
                    content = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<CE_LoginUserResp>(content?.ToString());
                }

            }
            catch (Exception ex)
            {
                result = new CE_LoginUserResp() { message = "Error.", issuccess = false };
            }


            return result;

        }


    }
}
