using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFistDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassInfoCF
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(32)]
        [Required]
        public string ClassName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }
        public virtual ICollection<StudentInfoCF> StudentInfoCF { get; set; }
    }
}
