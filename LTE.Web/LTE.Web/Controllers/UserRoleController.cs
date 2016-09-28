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

        public ActionResult Create()
        {
            var roleVm = new ApplicationRoleViewModel();
            return View(roleVm);
        }

        [HttpPost]
        public ActionResult Create(ApplicationRoleViewModel roleVm)
        {
            if (ModelState.IsValid)
            {
                bool isExitsRole = RoleManager.RoleExists(roleVm.Name);
                if (isExitsRole)
                {
                    ModelState.AddModelError("Name", string.Format("The name {0} is already taken.", roleVm.Name));
                    return View(roleVm);
                }

                var role = new ApplicationRole { Name = roleVm.Name, Description = roleVm.Description };
                var result = RoleManager.Create(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                AddModelError(result);
            }

            return View(roleVm);
        }

        private void AddModelError(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
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
        public ActionResult Edit(ApplicationRoleViewModel roleVm)
        {
            if (ModelState.IsValid)
            {
                bool isExitsRole = RoleManager.Roles.Any(r => r.Id != roleVm.Id && r.Name == roleVm.Name);
                if (isExitsRole)
                {
                    ModelState.AddModelError("Name", string.Format("The name {0} is already taken.", roleVm.Name));
                    return View(roleVm);
                }

                var role = RoleManager.FindById(roleVm.Id);
                role.Name = roleVm.Name;
                role.Description = roleVm.Description;
                var result = RoleManager.Update(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                AddModelError(result);
            }

            return View(roleVm);
        }

        public ActionResult Delete(string id)
        {
            var role = RoleManager.FindById(id);
            RoleManager.Delete(role);
            return RedirectToAction("Index");
        }
    }
}