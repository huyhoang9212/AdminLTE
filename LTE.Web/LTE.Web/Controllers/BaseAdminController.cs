using LTE.Web.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTE.Web.Controllers
{
    public abstract partial class BaseAdminController : Controller
    {
        public virtual void SusscessNotification(string message)
        {
            AddNotification(NotifyType.Success, message);
        }

        public virtual void ErrorNotification(IEnumerable<string> messages)
        {
            foreach(var message in messages)
            {
                AddNotification(NotifyType.Error, message);
            }
        }

        public virtual void ErrorNotification(string message)
        {
            AddNotification(NotifyType.Error, message);
        }

        public virtual void WarningNotification(string message)
        {
            AddNotification(NotifyType.Warning, message);
        }

        public virtual void AddNotification(NotifyType type, string message)
        {
            string key = string.Format("lte.notification.{0}", type);
            if(TempData[key] == null)
            {
                TempData[key] = new List<string>();
            }

            ((List<string>)TempData[key]).Add(message);
        }
    }
}