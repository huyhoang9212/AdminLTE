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
using System.IO;
using System.Collections;

namespace LTE.Web.Controllers
{
    public class CustomerController : BaseAdminController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        private readonly int _pagedSize = 5;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set { _userManager = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set { _roleManager = value; }
        }

        // GET: Customer
        public ActionResult Index()
        {
            var searchViewModel = new CustomerSearchViewModel();
            PrepareCustomerRolesModel(searchViewModel);

            return View(searchViewModel);
        }

        [NonAction]
        protected virtual void PrepareCustomerRolesModel(CustomerSearchViewModel model)
        {
            var roles =RoleManager.Roles.ToList();
            foreach (var role in roles)
            {
                model.AvailabelCustomerRoles.Add(new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Id
                });
            }
        }

        public PartialViewResult CustomerList(CustomerSearchViewModel searchViewModel, int page)
        {
            var customers = UserManager.GetAllUsers(page, _pagedSize, searchViewModel.SearchEmail,
                searchViewModel.SearchFristName,
                searchViewModel.SearchLastName,
                searchViewModel.SearchCustomerRoles);
            var customersVm = customers.Select(PrepareCustomerViewModelForList);
            PagedList<CustomerViewModel> pagedListCustomers = new PagedList<CustomerViewModel>(customersVm, page, _pagedSize, customers.TotalItems);

            return PartialView("_CustomerTablePartial", pagedListCustomers);
        }

        public ActionResult List(int page = 1)
        {
            var viewModel = new CustomerListModel();

            //var customers = UserManager.GetAllUsers(page,"","","");
            //var customerVms = customers.Select(PrepareCustomerViewModelForList);
            //var pagedList = new PagedList<CustomerViewModel>(customerVms, page, _pagedSize, customers.TotalItems);

            //viewModel.Customers = pagedList;

            return View(viewModel);
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