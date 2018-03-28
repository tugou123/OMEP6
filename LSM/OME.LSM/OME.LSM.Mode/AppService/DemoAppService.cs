using OEM.LSM.Write.Contract.Servces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Mode.AppService
{
    public class DemoAppService : IDemoAppService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public  async Task<string> GetV(string tx)
        {
            return await Task<string>.Factory.StartNew(() => { return $"the is TestDemo  {tx}"; });
        }

        public async Task<string> Hello()
        {
            return await Task<string>.Factory.StartNew(() => { return $"this time now {DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")}"; });
        }
    }
}
