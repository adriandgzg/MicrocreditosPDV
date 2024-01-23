using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_PaymentCreditResp
    {
        private bool _issuccess = false;
        private PaymentCreditSuccess _data;
        private string _message;
        private int _status_code;

        public bool issuccess { get => _issuccess; set => _issuccess = value; }
        public PaymentCreditSuccess data { get => _data; set => _data = value; }
        public string message { get => _message; set => _message = value; }
        public int status_code { get => _status_code; set => _status_code = value; }
    }
}
