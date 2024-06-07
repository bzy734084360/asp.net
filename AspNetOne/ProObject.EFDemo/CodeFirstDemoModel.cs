using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProObject.EFDemo
{
    /// <summary>
    /// 代码先行
    /// </summary>
    public class CodeFirstDemoModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [StringLength(32)]
        [Required]
        public string Name { get; set; }
    }
}