using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
namespace OEM.LSM.Write.Contract.Componet
{
  public  interface IDemoComponet: IDisposable
    {
        Task<string> GetV(string tx);
        Task<string> Hello();
    }
}
