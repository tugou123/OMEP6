using OEM.LSM.Write.Contract.InputDao;
using OEM.LSM.Write.Contract.Servces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OME.Expand;

namespace OME.LSM.Mode
{
    public class CollectUserAppService : ICollectUserAppService
    {
        LSMDBContext db;
        public CollectUserAppService()
        {
            db= new LSMDBContext();
        }
        public async Task AddCollectUser(CollectUserRequest collectUserRequest)
        {      
          await Task.Run(async () => {
                var Tc = collectUserRequest.MapTo<CollectUsert>();
              db.CollectUserts.Add(Tc);
              Tc.IsDelete = false;
              Tc.IsActive = false;
              Tc.CollectUserState = Info.Enums.LSM.CollectUserState.Examineandverify;

              await db.SaveChangesAsync();
          });

        }

        public async Task DeleteCollectUser(long Id, long Carrid)
        {
            await Task.Run(async () =>
            {

                var _colleruser = db.CollectUserts.Where(n => n.Id == Id).FirstOrDefault(); ;
                if (_colleruser == null)
                {
                    throw new Exception("collectuserdetailes_No_corresponding_information_was_found");
                }
                if (!_colleruser.IsDelete)
                {
                    _colleruser.IsDelete = false;
                }
                await db.SaveChangesAsync();
            });
          
        }

        public void Dispose()
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
    }
}
