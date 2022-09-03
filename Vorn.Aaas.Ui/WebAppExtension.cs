using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

public static class WebAppExtension
{
    public static void AddAaasUi(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "cookies";
            options.DefaultChallengeScheme = "oidc";
        })
        .AddCookie("cookies")
        .AddOpenIdConnect("oidc", options =>
        {
            options.Authority = builder.Configuration["Aaas:Authority"];
            options.ClientId = builder.Configuration["Aaas:ClientId"];
            options.MapInboundClaims = false;
            options.SaveTokens = true;
            options.Scope.Add("access");
        });
        builder.Services.AddAuthorization(c =>
        {
            var pb = new AuthorizationPolicyBuilder()
               .RequireAuthenticatedUser();
            string requiredAccess = builder.Configuration["Aaas:Access"];
            if(requiredAccess != null)
                pb = pb.RequireClaim("access", requiredAccess);
            c.DefaultPolicy = pb.Build();
        });
        builder.Services.AddMudServices();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
    }
    public static void Run(this WebApplicationBuilder builder )
    {
        var app = builder.Build();
        app.UseExceptionHandler("/Error");
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        app.Run();
    }
}