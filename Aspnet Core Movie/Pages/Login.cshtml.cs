using Aspnet_Core_Movie.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Aspnet_Core_Movie.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);

                if (identityResult.Succeeded)
                {
                    return returnUrl == null || returnUrl == "/" ? RedirectToPage("Index") : RedirectToPage(returnUrl);
                }
            }

            ModelState.AddModelError("", "Incorrect Username and Password!");
            return Page();
        }
    }
}