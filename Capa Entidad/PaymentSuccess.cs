using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class PaymentSuccess
    {
        private double _amount_pay;
        private double _amount_discount;
        private int _amount_points;
        private int _idcode;
        private CE_InfoCLient _info_client;

        public double amount_pay { get => _amount_pay; set => _amount_pay = value; }
        public double amount_discount { get => _amount_discount; set => _amount_discount = value; }
        public int amount_points { get => _amount_points; set => _amount_points = value; }
        public int idcode { get => _idcode; set => _idcode = value; }
        public CE_InfoCLient info_client { get => _info_client; set => _info_client = value; }
    }
}
