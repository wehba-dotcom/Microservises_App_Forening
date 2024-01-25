using IdentityService.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityService.Core.ViewModels
{
    public class EditUserViewModel
    {
        public IdentityServiceUser User { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}
