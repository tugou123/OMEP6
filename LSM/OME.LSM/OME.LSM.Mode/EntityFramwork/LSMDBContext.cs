using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Mode
{
   public class LSMDBContext:DbContext
    {
        public LSMDBContext():base(Setting.DbConfig.Get())
        {

        }

        /// <summary>
        /// 揽件人信息
        /// </summary>
        public IDbSet<CollectUsert> CollectUserts { set; get; }

    }
}
