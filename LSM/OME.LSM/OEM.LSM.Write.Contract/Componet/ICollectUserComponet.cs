using OEM.LSM.Write.Contract.InputDao;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEM.LSM.Write.Contract.Componet
{
   public  interface ICollectUserComponet: IGrainWithStringKey
    {
        /// <summary>
        /// 添加揽件人
        /// </summary>
        /// <param name="collectUserRequest"></param>
        /// <returns></returns>
        Task AddCollectUser(CollectUserRequest collectUserRequest);

        /// <summary>
        /// 删除揽人
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Carrid"></param>
        /// <returns></returns>
        Task DeleteCollectUser(long Id, long Carrid);
        /// <summary>
        /// 启用 禁用揽件人
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Carrid"></param>
        /// <returns></returns>

        Task IsDisableCollectUser(long Id, long Carrid, bool Trg);
        /// <summary>
        /// 更新揽件人
        /// </summary>
        /// <param name="collectUserRequest"></param>
        /// <returns></returns>
        Task UpCollectUser(CollectUserRequest collectUserRequest);
    }
}
