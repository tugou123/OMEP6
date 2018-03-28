using OME.Unity;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Facade
{
   public interface  IBaseConfigruation:IDisposable
    {
        Task Configurations();
    }




    public class BaseConfigruation : Grain, IBaseConfigruation
    {
        public BaseConfigruation()
        {
            Configurations().Wait();
        }

        public BaseConfigruation(string C)
        {

        }
        public async Task Configurations()
        {
            await Task.Run(() =>
            {
                UnityIoc.containerName = "lsm_Component_container";
                UnityIoc.filepath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "UntityConfig\\LSM\\") + "Lsm_Componet_Unity.config";
                var sx = System.Environment.CurrentDirectory;
                Console.WriteLine(sx);
            });
           
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
