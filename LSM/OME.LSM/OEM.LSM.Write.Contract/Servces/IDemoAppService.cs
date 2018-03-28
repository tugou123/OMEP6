using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEM.LSM.Write.Contract.Servces
{
   public  interface IDemoAppService: IDisposable
    {
        Task<string> GetV(string tx);
        Task<string> Hello();
    }
}
