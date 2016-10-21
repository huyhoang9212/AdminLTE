using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LTE.Web.ViewModels.Customer
{
    public class CustomerSearchViewModel
    {
        public CustomerSearchViewModel()
        {
            AvailabelCustomerRoles = new List<SelectListItem>();
        }

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

        public IEnumerable<string> SearchCustomerRoles { get; set; }

        public IList<SelectListItem> AvailabelCustomerRoles { get; set; }
    }
}