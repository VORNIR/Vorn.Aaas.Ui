using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Reflection;
using Vorn.Aaas.Ui;

public static class WebAppExtension
{
    public static void AddAaasUi(this WebApplicationBuilder builder, IEnumerable<Assembly>? additionalAssemblies = null)
    {
        string section = "Vorn:Aaas";
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "cookies";
            options.DefaultChallengeScheme = "oidc";
        })
        .AddCookie("cookies")
        .AddOpenIdConnect("oidc", options =>
        {
            options.Authority = builder.Configuration[$"{section}:Authority"];
            options.ClientId = builder.Configuration[$"{section}:ClientId"];
            options.MapInboundClaims = false;
            options.SaveTokens = true;
            options.Scope.Add("access");
        });
        builder.Services.AddAuthorization(c =>
        {
            var pb = new AuthorizationPolicyBuilder()
               .RequireAuthenticatedUser();
            string requiredAccess = builder.Configuration[$"{section}:Access"];
            if(requiredAccess != null)
                pb = pb.RequireClaim("access", requiredAccess);
            c.DefaultPolicy = pb.Build();
        });
        builder.Services.AddMudServices();
        var mvc = builder.Services.AddRazorPages();
        var execAss = Assembly.GetExecutingAssembly();
        var callAss = Assembly.GetCallingAssembly();
        mvc.AddApplicationPart(execAss);
        mvc.AddApplicationPart(callAss);
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton(new AdditionalAssembliesRegistry(callAss, additionalAssemblies));
        builder.Services.AddTransient<ITagHelperComponent, AssetTags>();
    }
    public static void Run(this WebApplicationBuilder builder)
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