using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tez.WebUI.Models;

namespace Tez.WebUI.HtmlHelpers
{
	public static class PagingHelpers
	{
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage); i++)
            {
                var tagBuild = new TagBuilder("li");
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", String.Format("/Tez/Index/?page=" + i));
                tagBuilder.InnerHtml = i.ToString();
                
                if (i == pagingInfo.CurrentPage)
                {
                    tagBuild.AddCssClass("active");
                }
                tagBuild.InnerHtml += tagBuilder.ToString();
                stringBuilder.Append(tagBuild);
                //stringBuilder.Append(tagBuilder);
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}