using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CECreditPayment
    {
        private int _idcode;
        private double _amount_pay;
        private int _idclient;
        private int _idcredit;
        private string _branch_number;

        public int idcode { get => _idcode; set => _idcode = value; }
        public double amount_pay { get => _amount_pay; set => _amount_pay = value; }
        public int idclient { get => _idclient; set => _idclient = value; }
        public int idcredit { get => _idcredit; set => _idcredit = value; }
        public string branch_number { get => _branch_number; set => _branch_number = value; }
    }
}
