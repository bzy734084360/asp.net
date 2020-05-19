using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcStudy.Models
{
    public class UserInfoValidate
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string UserPwd { get; set; }
        public DateTime? RegDate { get; set; }
    }
    [MetadataType(typeof(UserInfoValidate))]
    public partial class UserInfo
    {

    }
}