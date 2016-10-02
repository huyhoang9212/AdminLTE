using LTE.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.Mvc.Html;

namespace LTE.Web.Utilities
{
    public static class HtmlExtentions
    {

        public static MvcHtmlString DeleteConfirmation<T>(this HtmlHelper<T> helper, string modalId)
            where T : BaseViewModel
        {
            string actionDelete = "Delete";
            string controller = helper.ViewContext.RouteData.GetRequiredString("controller");
            return DeleteConfirmation<T>(helper, modalId, actionDelete, controller);
        }

        public static MvcHtmlString DeleteConfirmation<T>(this HtmlHelper<T> helper, string modalId,
            string actionDelete, string controller)
            where T : BaseViewModel
        {
            string modalLabel = MvcHtmlString.Create(helper.ViewData.ModelMetadata.ModelType.Name.ToLower() + "-delete-confirmation-title").ToHtmlString();
            StringBuilder builder = new StringBuilder();
            var deleteConfirmationVm = new DeleteConfirmationViewModel
            {
                Id = helper.ViewData.Model.Id,
                ActionDelete = actionDelete,
                Controller = controller,
                WindowId = modalLabel
            };

            builder.AppendLine(string.Format("<div class=\"modal fade\" id={0} tabindex=\"-1\" role=\"dialog\" aria-labelledby={1} >", modalId, modalLabel));
            builder.AppendLine(helper.Partial("_DeleteConfirmation", deleteConfirmationVm).ToHtmlString());
            builder.AppendLine("</div>");
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}