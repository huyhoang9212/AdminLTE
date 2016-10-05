using LTE.Web.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using LTE.Web.Models;

namespace LTE.Web.Controllers
{
    public class CustomerController : BaseAdminController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManger
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set { _userManager = value; }
        }

        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            //var customersVm = new List<CustomerViewModel>();
            var customers = UserManger.Users.ToList();
            var customersVm = customers.Select(PrepareCustomerViewModelForList);

            //foreach(var customer in customers)
            //{
            //    var customerVm = new CustomerViewModel
            //    {
            //        Active = customer.LockoutEnabled,
            //        Company = customer.Company,
            //        DateOfBirth = customer.DateOfBirth,
            //        Email = customer.Email,
            //        FirstName = customer.FirstName,
            //        Id = customer.Id,
            //        LastName = customer.LastName
            //    };

            //    customersVm.Add(customerVm);
            //}

            return View(customersVm);
        }

        [NonAction]
        protected virtual CustomerViewModel PrepareCustomerViewModelForList(ApplicationUser customer)
        {
            return  new CustomerViewModel
            {
                Active = customer.LockoutEnabled,
                Company = customer.Company,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                FirstName = customer.FirstName,
                Id = customer.Id,
                LastName = customer.LastName
            };
        }
    }
}