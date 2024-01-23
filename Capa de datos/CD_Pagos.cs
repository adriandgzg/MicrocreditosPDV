using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class CD_Pagos
    {
        HttpClient _client;
        public CD_Pagos()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
        }

        public void GetBearerTokenAsync(string token)
        {
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<CE_PaymentResp> BuscarCodigoPago(CE_CodePayment pUser, string token)
        {
            CE_PaymentResp result = null;
            var uri = new Uri(string.Format(Configuration.URL_INFO_CODE_PRODUCT));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpCLient = new HttpClient())
                {
                    if (token != null)
                    {
                        httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    string? content;
                    var response1 = await httpCLient.PostAsync(uri, httpcontent);
                    content = await response1.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<CE_PaymentResp>(content?.ToString());
                }

            }
            catch (Exception ex)
            {
                result = new CE_PaymentResp() { message = "Error.", issuccess = false };
            }
            return result;
        }

        public async Task<CE_PaymentCreditResp> BuscarCodigoAbono(CE_CodePayment pUser, string token)
        {
            
            CE_PaymentCreditResp result = null;

            var uri = new Uri(string.Format(Configuration.URL_INFO_CODE_CREDIT));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpCLient = new HttpClient())
                {
                    if (token != null)
                    {
                        httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    string? content;
                    var response = await httpCLient.PostAsync(uri, httpcontent);
                    content = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<CE_PaymentCreditResp>(content?.ToString());
                }

            }
            catch (Exception ex)
            {
                result = new CE_PaymentCreditResp() { message = "Error.", issuccess = false };
            }

            return result;
        }

        public async Task<CE_PaymentCreditResp> PagarCredito(CECreditPayment pUser, string token)
        {
            
            CE_PaymentCreditResp result = null;

            var uri = new Uri(string.Format(Configuration.URL_PAY_CREDIT));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpCLient = new HttpClient())
                {
                    if (token != null)
                    {
                        httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }   
                    string? content;
                    var response = await httpCLient.PostAsync(uri, httpcontent);
                    content = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<CE_PaymentCreditResp>(content?.ToString());
                }

            }
            catch (Exception ex)
            {
                result = new CE_PaymentCreditResp() { message = "Error.", issuccess = false };
            }

            return result;
        }

        public async Task<CE_PaymentResp> PagarProducto(CE_PayPayment pUser, string token)
        {
           
            CE_PaymentResp result = null;

            var uri = new Uri(string.Format(Configuration.URL_PAY_PRODUCT));
            var json = JsonSerializer.Serialize(pUser);

            HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpCLient = new HttpClient())
                {
                    if (token != null)
                    {
                        httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    string? content;
                    var response = await httpCLient.PostAsync(uri, httpcontent);
                    content = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<CE_PaymentResp>(content?.ToString());
                }

            }
            catch (Exception ex)
            {
                result = new CE_PaymentResp() { message = "Error.", issuccess = false };
            }

            return result;
        }
    }
}
