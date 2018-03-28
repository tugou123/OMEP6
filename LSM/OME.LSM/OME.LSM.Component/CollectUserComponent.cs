using OEM.LSM.Write.Contract.Componet;
using OEM.LSM.Write.Contract.InputDao;
using OEM.LSM.Write.Contract.Servces;
using OME.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Component
{
    public class CollectUserComponent : BaseConfigruation, ICollectUserComponet
    {
        public ICollectUserAppService _collectUserAppService;
        public CollectUserComponent():base()
        {
            _collectUserAppService = UnityIoc.DBInstance.GetService<ICollectUserAppService>();
        }
        public async Task AddCollectUser(CollectUserRequest collectUserRequest)
        {
           await Task.Delay(1000);
            Console.WriteLine($"我是调用你接口的 AddCollectUser");

         //   IsCollectUser(collectUserRequest);
          // await _collectUserAppService.AddCollectUser(collectUserRequest);
        }

        public Task DeleteCollectUser(long Id, long Carrid)
        {
            throw new NotImplementedException();
        }

        public Task IsDisableCollectUser(long Id, long Carrid, bool Trg)
        {
            throw new NotImplementedException();
        }

        public Task UpCollectUser(CollectUserRequest collectUserRequest)
        {
            throw new NotImplementedException();
        }


        public void IsCollectUser(CollectUserRequest collectUserRequest)
        {
            if (collectUserRequest == null)
            {
                throw new Exception("collectUserRequest_Request_parameters_are_empty");
            }
            if (string.IsNullOrEmpty(collectUserRequest.IDCard))
            {
                throw new Exception("the_idcard_required");
            }
            if (string.IsNullOrEmpty(collectUserRequest.CollectUserName))
            {
                throw new Exception("the_collect_name_required");
            }
            if (string.IsNullOrEmpty(collectUserRequest.Phone))
            {
                throw new Exception("the_collect_phone_required");
            }
            if (string.IsNullOrEmpty(collectUserRequest.HeaderImage))
            {
                throw new Exception("the_collect_headerimage_required");
            }
        }
    }
}
