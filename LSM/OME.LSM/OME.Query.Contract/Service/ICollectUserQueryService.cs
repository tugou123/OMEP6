using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
namespace OME.LSM.Query.Contract
{
  public   interface ICollectUserQueryService:IGrainWithIntegerKey
    {
        /// <summary>
        /// 获取揽件人信息集合
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<IEnumerable<CollectUser>> CollectUserlist(long carrid);

        /// <summary>
        /// 获取揽件人个人详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CollectUser> GetCollectuser(long Id);



    }
}
