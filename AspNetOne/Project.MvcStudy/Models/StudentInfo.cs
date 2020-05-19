using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcStudy.Models
{
    public class StudentInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "用户名不能为空")]
        public string StuName { get; set; }
        [Required(ErrorMessage = "邮箱不能为空")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "邮箱格式错误")]
        public string StuMail { get; set; }
        public DateTime dateTime { get; set; }
    }
}