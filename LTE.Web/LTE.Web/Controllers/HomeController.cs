using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using LTE.Web.ViewModels.Home;
using LTE.Core;
using LTE.Data;
using LTE.Services;

namespace LTE.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private ICategoryService _categoryService;
        private IUnitOfWork _unitOfWork;

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
        
        public HomeController( ICategoryService service, IUnitOfWork unitOfWork)
        {          
            _categoryService = service;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexHomeViewModel()
            {
                NumberUser = UserManager.Users.Count(),
                NumberRole = RoleManager.Roles.Count(),
                NumberCategory = _categoryService.GetAllCategories().Count()
            };
            
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}