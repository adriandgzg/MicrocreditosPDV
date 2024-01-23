using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_RefreshToken
    {
        private string _refresh_token;

        public string refresh_token { get => _refresh_token; set => _refresh_token = value; }
    }
}
