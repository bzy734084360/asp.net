using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
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
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append($"<a href='NewList.aspx?pageIndex={i}'>{i}</a>");
                }
            }
            return sb.ToString();
        }
    }
}
