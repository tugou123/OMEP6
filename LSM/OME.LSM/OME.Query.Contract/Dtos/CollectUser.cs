using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Query.Contract
{
    public class CollectUser
    {
        public long Id { set; get; }
        /// <summary>
        /// 揽件人姓名
        /// </summary>
        public string CollectUserName { set; get; }
        /// <summary>
        /// 揽件人代码
        /// </summary>
        public  string CollectCode { set; get; }

        /// <summary>
        /// 揽件人 电话
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 揽件人Id
        /// </summary>
        public string IDCard { set; get; }


        
    }
}
