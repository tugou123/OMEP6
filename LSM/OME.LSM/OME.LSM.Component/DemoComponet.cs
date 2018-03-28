using OEM.LSM.Write.Contract.Componet;
using OEM.LSM.Write.Contract.Servces;
using OME.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Component
{
    public class DemoComponet : BaseConfigruation, IDemoComponet
    {
        IDemoAppService _demoAppService;
        public DemoComponet() : base()
        {
            _demoAppService = UnityIoc.DBInstance.GetService<IDemoAppService>();
        }
        public async Task<string> GetV(string tx)
        {
           return  await _demoAppService.GetV(tx);
           
        }
        public async Task<string> Hello()
        {
            return await _demoAppService.Hello();
          
        }
    }
}
