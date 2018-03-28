using OME.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.LSM.Query.Daos.Base
{
   public  class QuerySqlServerDao:BaseSqlServerDao
    {
        public QuerySqlServerDao() : base(Setting.DbConfig.Get()) { }
    }
}
