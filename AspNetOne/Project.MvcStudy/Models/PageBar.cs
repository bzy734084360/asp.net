using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MvcStudy.Models
{
    public class PageBar
    {
        /// <summary>
        /// 获取数字页码条
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;//如果只有一页，则不会出现数字页码条
            }
            //要求页面显示10个页码
            int start = pageIndex - 5;
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;
            if (end > pageCount)
            {
                end = pageCount;
                start = pageCount - 9 > 1 ? pageCount - 9 : 1;
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)
            {
                sb.Append($"<a href='?pageIndex={pageIndex - 1}' class='myPageBar'>上一页</a>");
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append($"<a href='?pageIndex={i}'  class='myPageBar'>{i}</a>");
                }
            }
            if (pageIndex < pageCount)
            {
                sb.Append($"<a href='?pageIndex={pageIndex + 1}' class='myPageBar'>下一页</a>");
            }
            return sb.ToString();
        }
    }
}
