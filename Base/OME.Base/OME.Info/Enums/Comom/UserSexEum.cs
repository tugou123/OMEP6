using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.Info.Enums.Comom
{
    /// <summary>
    /// 性别
    /// </summary>
   public enum SEX
    {
        [Display(Name = "男")]
        male =100,
        [Display(Name = "女")]
        female =200,
    }

}
