using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProObject.EFDemo
{
    /// <summary>
    /// 扩展方法所在的类必须是静态类。
    /// 扩展方法必须是静态方法。
    /// 第一个参数必须是this关键字后面跟的是给哪个类型扩展的。
    /// </summary>
    public static class StringExt
    {
        public static string MyStr(this string strMsg)
        {
            return $"<font color='red'>{strMsg}</font>";
        }
    }
}