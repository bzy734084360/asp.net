using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        public int UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime RegDate { get; set; }


    }
}
