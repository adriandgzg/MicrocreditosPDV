using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class Configuration
    {
        public static string BASE_ADDRRESS = "http://3.228.168.171:8080/";

        // Autentificación
        public static string URL_LOGIN_PASSWORD = BASE_ADDRRESS + "api/auth/login-user";

        public static string URL_REFRESH_TOKEN = BASE_ADDRRESS + "api/auth/login-client-refresh";

        public static string URL_INFO_CODE_PRODUCT = BASE_ADDRRESS + "api/credit/info-code-product";

        public static string URL_INFO_CODE_CREDIT = BASE_ADDRRESS + "api/credit/info-code-credit";

        public static string URL_PAY_CREDIT = BASE_ADDRRESS + "api/credit/credit-payment";
        public static string URL_PAY_PRODUCT = BASE_ADDRRESS + "api/credit/payments";
    }
}