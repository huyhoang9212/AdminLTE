using LTE.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LTE.Web.ViewModels.Customer
{
    public class CustomerListModel
    {
        [Display(Name = "Email")]
        public string SearchEmail { get; set; }

        [Display(Name = "First name")]
        public string SearchFristName { get; set; }

        [Display(Name = "Last name")]

        public string SearchLastName { get; set; }

        [Display(Name = "Date of birth")]

        public int SearchDobMonth { get; set; }

        [Display(Name = "Date of birth")]

        public int SearchDobDay { get; set; }

        [Display(Name = "Company")]

        public string SearchCompany { get; set; }

        [Display(Name = "Customer roles")]

        public IList<string> SearchCustomerRoles { get; set; }

        public PagedList<CustomerViewModel> Customers { get; set; }
    }
}