using Dapper;
using OME.LSM.Query.Contract;
using OME.LSM.Query.Daos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Query.Daos
{
   public  class CollectUserDao:QuerySqlServerDao
    {
        /// <summary>
        /// 承运商 ID
        /// </summary>
        /// <param name="carrid"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CollectUser>> CollectUserlist(long carrid)
        {
            return (await InvokeAsync(           
                async () => await Connection.QueryAsync<CollectUser>("select * from UserCollect")   
            ));
        }
        public async Task<CollectUser> GetCollectuser(long Id)
        {
            return (await InvokeAsync(async () => 
                await Connection.QueryAsync<CollectUser>("select * from UserCollect")
            )).FirstOrDefault();
        }
    }
}
