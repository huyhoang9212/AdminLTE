using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Linq;
using LTE.Web.Models;
using LTE.Web.ViewModels.UserRoles;
namespace LTE.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserRoleController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UserRoleController()
        {

        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }

        public ActionResult Index()
        {
            var roles = RoleManager.Roles.ToList();
            ViewBag.Description = "manage roles";
            return View(roles);
        }

        public ActionResult Edit(string id)
        {
            var role = RoleManager.FindById(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            var roleVm = new ApplicationRoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(roleVm);
        }

        [HttpPost]
        public ActionResult UpdateRole(ApplicationRoleViewModel roleVm)
        {
            var role = RoleManager.FindById(roleVm.Id);
            role.Name = roleVm.Name;
            role.Description = roleVm.Description;
            RoleManager.Update(role) ;
            return RedirectToAction("Index");
        }
    }
}