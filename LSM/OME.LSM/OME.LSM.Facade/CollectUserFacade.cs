using OEM.LSM.Write.Contract.Componet;
using OEM.LSM.Write.Contract.Facade;
using OEM.LSM.Write.Contract.InputDao;
using OME.LSM.Query.Contract;
using OME.Unity;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Facade
{
    public class CollectUserFacade : BaseConfigruation, ICollectUserFacade
    {

        //private async Task InnerAop(Func<Task> func,Action<Exception> action = null)
        //{
        //    await InnerAopBase()
        //}


        //  private Lazy<ICollectUserComponet> _icollectusercomponet;

        ICollectUserComponet _icollecuser;

        public CollectUserFacade()
        {
            _icollecuser = UnityIoc.DBInstance.GetService<ICollectUserComponet>();
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
        public async Task AddCollectUser(CollectUserRequest collectUserRequest)
        {
            await InnerAop(async () =>
            {
                await _icollecuser.AddCollectUser(collectUserRequest);
            });
        }

        public async Task DeleteCollectUser(long Id, long Carrid)
        {
            await Task.Delay(100);
        }

        public async Task IsDisableCollectUser(long Id, long Carrid, bool Trg)
        {
            await Task.Delay(100);
        }

        public async Task UpCollectUser(CollectUserRequest collectUserRequest)
        {
            await Task.Delay(100);
        }
    }
}
