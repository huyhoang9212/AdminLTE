using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTE.Web.ViewModels.Customer
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public IEnumerable<string> Roles { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Company { get; set; }
        public bool Active { get; set; }
    }
}