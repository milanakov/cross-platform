using System.Net.Http.Headers;
using System.Security.Claims;
using lab5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Controllers;

public class AccountController : Controller
{
    public IActionResult Login(string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
    }

    public async Task Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult Profile()
    {
        var userClaims = User.Claims;

        var model = new UserProfileViewModel
        {
            Nickname = userClaims.FirstOrDefault(c => c.Type == "nickname")?.Value,
            Email = userClaims.FirstOrDefault(c => c.Type == "name")?.Value,
            Phone = userClaims.FirstOrDefault(c => c.Type == "phoneNumber")?.Value,
            FullName = userClaims.FirstOrDefault(c => c.Type == "fullname")?.Value

        };

        return View(model);
    }

    private async Task<string> GetUserPhoneNumberAsync(string userId)
    {
        // Logic to retrieve phone number from your database or Auth0
        // Replace with actual implementation
        return "Retrieved Phone Number";
    }

}

