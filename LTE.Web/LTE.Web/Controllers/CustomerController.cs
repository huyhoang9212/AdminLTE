using LTE.Web.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LTE.Web.Models;
using LTE.Web.ViewModels;
using LTE.Core;

namespace LTE.Web.Controllers
{
    public class CustomerController : BaseAdminController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
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

        public ActionResult List(int page = 1)
        {
            int pagedSize = 5;
            //var pageList = UserManager.GetUsers(page);
            var customers = UserManager.GetAllUsers(page);
            var customerVms = customers.Select(PrepareCustomerViewModelForList);
            var pagedList = new PagedList<CustomerViewModel>(customerVms, page, pagedSize, customers.TotalItems);

            //ViewBag.Data = pagedList.Select(PrepareCustomerViewModelForList);
            return View(pagedList);
        }

        [NonAction]
        protected CustomerViewModel PrepareCustomerViewModelForList(ApplicationUser customer)
        {
            var customerVm = new CustomerViewModel
            {
                Active = customer.LockoutEnabled,
                Company = customer.Company,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                FirstName = customer.FirstName,
                Id = customer.Id,
                LastName = customer.LastName,
                Roles = UserManager.GetRoles(customer.Id)
            };

            return customerVm;
        }
    }
}