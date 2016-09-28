using System.ComponentModel.DataAnnotations;

namespace LTE.Web.ViewModels.UserRoles
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}