using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_InfoCLient
    {
        private int _idcliente;
        private string _fullname;
        private string _users_status_id;
        private string _name;
        private string _last_name;
        private string _paternal_surname;
        private string _mother_surname;

        public int idcliente { get => _idcliente; set => _idcliente = value; }
        public string fullname { get => _fullname; set => _fullname = value; }
        public string users_status_id { get => _users_status_id; set => _users_status_id = value; }
        public string name { get => _name; set => _name = value; }
        public string last_name { get => _last_name; set => _last_name = value; }
        public string paternal_surname { get => _paternal_surname; set => _paternal_surname = value; }
        public string mother_surname { get => _mother_surname; set => _mother_surname = value; }
    }
}
