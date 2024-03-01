using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ToDoApp.Models;

namespace ToDoApp.Helpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString DisplayRowHelper(this HtmlHelper htmlHelper, ToDoItem item)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            TagBuilder tr = new TagBuilder("tr");

            TagBuilder tdId = new TagBuilder("td");
            tdId.SetInnerText(Convert.ToString(item.Id));
            tr.InnerHtml += tdId.ToString();

            TagBuilder tdTask = new TagBuilder("td");
            tdTask.SetInnerText(Convert.ToString(item.Task));
            tr.InnerHtml += tdTask.ToString();

            TagBuilder tdStatus = new TagBuilder("td");
            bool status = item.IsCompleted;
            tdStatus.InnerHtml = status ? "<span>Completed</span>" : "<span>Pending</span>";
            tr.InnerHtml += tdStatus.ToString();

            TagBuilder tdAction = new TagBuilder("td");
            TagBuilder editLink = new TagBuilder("a");
            editLink.MergeAttribute("href", urlHelper.Action("Edit", "ToDo", new { id = item.Id }).ToString());
            editLink.AddCssClass("btn btn-primary me-2");
            editLink.SetInnerText("Edit");
            tdAction.InnerHtml += editLink.ToString();

            TagBuilder deleteLink = new TagBuilder("a");
            deleteLink.MergeAttribute("href", urlHelper.Action("Delete", "ToDo", new { id = item.Id }).ToString());
            deleteLink.AddCssClass("btn btn-danger ms-2");
            deleteLink.SetInnerText("Delete");
            tdAction.InnerHtml += deleteLink.ToString();
            tr.InnerHtml += tdAction.ToString();

            return new MvcHtmlString(tr.ToString());
        }
    }
}
