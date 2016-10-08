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

        public ActionResult List(int page = 1)
        {
            int pageSize = 5;
            int totalItems = UserManger.Users.Count();
            int totalPage = (int)Math.Ceiling((double)UserManger.Users.Count() / pageSize);
            page = page > totalPage ? totalPage : page;

            var customers = UserManger.Users.OrderBy(c => c.Company)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize).ToList();
            var customersVm = customers.Select(PrepareCustomerViewModelForList);
            PageList<CustomerViewModel> pageList = new PageList<CustomerViewModel>()
            {
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPage = totalPage,
                CurrentPage = page,
                NumberOfPage = 5,
                Data = customersVm
            };
            return View(pageList);
        }

        [NonAction]
        protected virtual CustomerViewModel PrepareCustomerViewModelForList(ApplicationUser customer)
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
                Roles = UserManger.GetRoles(customer.Id)
            };

            return customerVm;
        }
    }
}