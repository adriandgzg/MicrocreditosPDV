using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_LoginUser
    {
        private string phone_number;
        private string password;

        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Password { get => password; set => password = value; }
    }
}
