using Capa_de_datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Pagos
    {
        private readonly CD_Pagos pagos = new CD_Pagos();

        public async Task<CE_PaymentResp> BuscarCodigoPago(CE_CodePayment ce_LoginUser, string token)
        {
            return await pagos.BuscarCodigoPago(ce_LoginUser, token);
        }

        public async Task<CE_PaymentCreditResp> BuscarCodigoAbono(CE_CodePayment ce_LoginUser, string token)
        {
            return await pagos.BuscarCodigoAbono(ce_LoginUser, token);
        }

        public async Task<CE_PaymentCreditResp> PagarCredito(CECreditPayment ce_LoginUser, string token)
        {
            return await pagos.PagarCredito(ce_LoginUser, token);
        }

        public async Task<CE_PaymentResp> PagarProducto(CE_PayPayment ce_LoginUser, string token)
        {
            return await pagos.PagarProducto(ce_LoginUser, token);
        }
    }
}
