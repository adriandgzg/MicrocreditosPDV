using Capa_de_datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_LoginUser
    {
        private readonly CD_LoginUser cD_LoginUser = new CD_LoginUser();

        public async Task<CE_LoginUserResp> Login(CE_LoginUser ce_LoginUser)
        {            
            return await cD_LoginUser.LoginPassword(ce_LoginUser);
        }

        public async Task<CE_LoginUserResp> RefreshToken(CE_RefreshToken ce_LoginUser)
        {
            return await cD_LoginUser.RefreshToken(ce_LoginUser);
        }
    }
}
