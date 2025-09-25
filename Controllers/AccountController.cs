using BTickets.Data;
using BTickets.Models;
using BTickets.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        public AccountController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            RoleManager = roleManager;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await context.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    UserName = registerVM.Username,
                    Email = registerVM.Email
                };
                var UserExist = await context.Users.AnyAsync(u => u.UserName == registerVM.Username || u.Email == registerVM.Email);
                if (UserExist)
                {
                    ModelState.AddModelError("", "Username or Email already exists. Please choose different ones.");
                    return View("Register", registerVM);
                }


                IdentityResult result = await UserManager.CreateAsync(appUser, registerVM.Password);

                if (result.Succeeded)
                {
                    var roleType = registerVM.FirstName == "Admin" ? "Admin" : "User";

                    var claims = new Claim(ClaimTypes.Role, roleType);


                    var roleResult = await UserManager.AddClaimAsync(appUser, claims);
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View("Register", registerVM);
                    }
                    await SignInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Login");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", registerVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await UserManager.FindByEmailAsync(loginUserVM.Email);

                if (appUser != null)
                {
                    bool isPasswordCorrect = await UserManager.CheckPasswordAsync(appUser, loginUserVM.Password);

                    if (isPasswordCorrect)
                    {
                        await SignInManager.SignInAsync(appUser, loginUserVM.RememberMe);
                        return RedirectToAction("Index", "Movies");
                    }
                }

                ModelState.AddModelError("", "Invalid email or password");
            }
            return View("Login", loginUserVM);
        }

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


    }

}