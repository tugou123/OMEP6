using OME.LSM.Query.Contract;
using OME.LSM.Query.Daos;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Query.Service
{
    public class CollectUserQuseryService : Grain, ICollectUserQueryService
    {
        /// <summary>
        /// 获取揽件人信息
        /// </summary>
        /// <param name="carrid"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CollectUser>> CollectUserlist(long carrid)
        {
           using(var dao=new CollectUserDao())
            {
                return await dao.CollectUserlist(carrid);
            }
        }
        /// <summary>
        /// 获取揽件人详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<CollectUser> GetCollectuser(long Id)
        {
            using (var dao = new CollectUserDao())
            {
                return await dao.GetCollectuser(Id);
            }
        }
    }
}
