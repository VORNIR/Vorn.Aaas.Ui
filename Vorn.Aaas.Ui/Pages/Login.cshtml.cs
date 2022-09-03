using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    public async Task OnGet(string redirectUri = "/")
    {
        AuthenticationProperties? authProps = new AuthenticationProperties { RedirectUri = redirectUri };
        await HttpContext.ChallengeAsync("oidc", authProps);
    }
}
