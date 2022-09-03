using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
public class LogoutModel : PageModel
{
    public IActionResult OnGetAsync() => SignOut(new AuthenticationProperties { RedirectUri = "/" }, "cookies", "oidc");
}