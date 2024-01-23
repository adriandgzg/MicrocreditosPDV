using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public interface IApiService
    {
        Task<CE_LoginUserResp> LoginPassword(CE_LoginUser pUser);
    }
}
