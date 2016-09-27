using System.ComponentModel.DataAnnotations;

namespace LTE.Web.ViewModels.UserRoles
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}