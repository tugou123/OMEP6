using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
namespace OEM.LSM.Write.Contract.Facade
{
   public interface IDemoFacade:IGrainWithStringKey
    {
        Task<string> GetV(string tx);

        Task<string> Hello();
    }
}
