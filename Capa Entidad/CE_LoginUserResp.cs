using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_LoginUserResp
    {
        private bool _issuccess = false;
        private Data _data;
        private string _message;
        private int _status_code;

        public bool issuccess { get => _issuccess; set => _issuccess = value; }
        public Data data { get => _data; set => _data = value; }
        public string message { get => _message; set => _message = value; }
        public int status_code { get => _status_code; set => _status_code = value; }
    }

    public class Data
    {
        private string _token;
        private string _refresh_token;
        private string _token_expiration_time;
        private bool _result = false;

        public string token { get => _token; set => _token = value; }
        public string refresh_token { get => _refresh_token; set => _refresh_token = value; }
        public string token_expiration_time { get => _token_expiration_time; set => _token_expiration_time = value; }
        public bool result { get => _result; set => _result = value; }
    }
}
