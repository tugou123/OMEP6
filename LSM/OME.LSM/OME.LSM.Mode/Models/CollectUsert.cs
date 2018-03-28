using Abp.Domain.Entities;
using OME.Info.Enums.LSM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OME.LSM.Mode
{
    public class CollectUsert: Entity<long>
    {
        [Display(Name="ID")]
        public new long Id { set; get; }

        /// <summary>
        /// 揽件人姓名
        /// </summary>
        [Display(Name = "揽件人姓名")]
        public string CollectUserName { set; get; }
        /// <summary>
        /// 揽件人代码
        /// </summary>
        [Display(Name = "揽件人代码")]
        public string CollectCode { set; get; }

        /// <summary>
        /// 揽件人 电话
        /// </summary>
        [Display(Name = "揽件人 电话")]
        public string Phone { set; get; }

        /// <summary>
        /// 揽件人Id
        /// </summary>
        [Display(Name = "揽件人Id")]
        public string IDCard { set; get; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "删除揽件人")]
        public bool IsDelete { set; get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public bool IsActive { set; get; }

        /// <summary>
        /// 头像
        /// </summary>
        [Display(Name = "头像")]
        public string HeaderImage { set; get; }

        /// <summary>
        /// 揽件人状态
        /// </summary>
        public CollectUserState CollectUserState { set; get; }


    }
}
