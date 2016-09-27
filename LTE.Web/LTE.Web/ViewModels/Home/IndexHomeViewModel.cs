using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTE.Web.ViewModels.Home
{
    public class IndexHomeViewModel
    {
        public int NumberRole { get; set; }

        public int NumberUser { get; set; }

        public int NumberCategory { get; set; }

        public string InstanceDbContextId { get; set; }
    }
}