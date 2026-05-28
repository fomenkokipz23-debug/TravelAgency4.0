using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Domain;
using TravelAgency.Web.Models;

namespace TravelAgency.Web.Controllers;

[Authorize]
public class AccountController : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        if (User.Identity?.IsAuthenticated == true) return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(UserRegistrationDto model)
    {
        if (!ModelState.IsValid) return View(model);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Name),
            new Claim(ClaimTypes.Email, model.Email)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Profile()
    {
        string currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value ?? "";
        string currentUserName = User.Identity!.Name!;

        var allBookings = AgencyRegistry.Instance.BookingService.GetActiveBookings();

        var myTours = allBookings
            .Where(b => b.Tourist.Email == currentUserEmail)
            .Select(b => b.SelectedTour)
            .ToList();

        ViewBag.UserName = currentUserName;
        ViewBag.UserEmail = currentUserEmail;

        return View(myTours);
    }
    
    [HttpPost]
    public IActionResult CancelBooking(string bookingId)
    {
        if (!string.IsNullOrEmpty(bookingId))
        {
            var targetGuid = Guid.Parse(bookingId);
            
            AgencyRegistry.Instance.BookingService.CancelBooking(targetGuid);
        }
        
        return RedirectToAction("Profile");
    }
}