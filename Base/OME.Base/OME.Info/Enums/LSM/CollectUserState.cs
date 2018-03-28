using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OME.Info.Enums.LSM
{
    public enum CollectUserState
    {
        [Display(Name = "通过")]
        PassThrough = 100,
        [Display(Name = "不通过")]
        NotPass = 200,
        [Display(Name = "启用")]
        Active = 300,
        [Display(Name = "禁用")]
        Disable = 400,
        [Display(Name = "待审核")]
        Examineandverify = 500,
        [Display(Name = "删除")]
        Delete = 999,
    }
}
