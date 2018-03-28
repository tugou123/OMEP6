using OEM.LSM.Write.Contract.Componet;
using OEM.LSM.Write.Contract.Facade;
using OME.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Facade
{
    public class DemoFacade : BaseConfigruation, IDemoFacade
    {
        IDemoComponet _demoComponet;
        public DemoFacade():base()
        {
            _demoComponet =   UnityIoc.DBInstance.GetService<IDemoComponet>();
        }

        public async Task<string> GetV(string tx)
        {
            if (string.IsNullOrEmpty(tx))
            {
                throw new Exception("tx is null");
            }
            tx+= this.GetHashCode().ToString();
           return  await _demoComponet.GetV(tx); ;
        }

        public async Task<string> Hello()
        {
            return await _demoComponet.Hello(); ;
        }

        private async Task InnerAop(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

    }
}
