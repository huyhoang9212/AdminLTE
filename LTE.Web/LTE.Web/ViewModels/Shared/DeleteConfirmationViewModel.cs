using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTE.Web.ViewModels
{
    public class DeleteConfirmationViewModel
    {
        public string Id { get; set; }
        public string ActionDelete { get; set; }
        public string Controller { get; set; }
        public string WindowId { get; set; }
    }
}