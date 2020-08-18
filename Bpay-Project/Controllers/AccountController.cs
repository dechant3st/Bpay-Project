using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bpay_Project.DB.Entities;
using Bpay_Project.DB.Extensions;
using Bpay_Project.DB.Interfaces;
using Bpay_Project.Models;
using Bpay_Project.Services;
using Bpay_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bpay_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICountryRepo countryRepo;
        private readonly IProvinceRepo provinceRepo;
        private readonly ICityRepo cityRepo;
        private readonly IBarangayRepo barangayRepo;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMailService mailService;

        public AccountController(ICountryRepo countryRepo,
            IProvinceRepo provinceRepo,
            ICityRepo cityRepo,
            IBarangayRepo barangayRepo,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IMailService mailService)
        {
            this.countryRepo = countryRepo;
            this.provinceRepo = provinceRepo;
            this.cityRepo = cityRepo;
            this.barangayRepo = barangayRepo;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.EmailAddress);

                // Sign-in to account
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.IsPersist, false);

                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    } 
                    else
                    {
                        return RedirectToAction("dashboard", "account");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt!");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Suffix = model.Suffix,
                    BirthDate = model.BirthDate,
                    Email = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.EmailAddress
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    // Generate Token and Link for Email Confirmation
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);

                    SendMail(user.Email, "Confirm your email via link!", confirmationLink);

                    // Sign-in to account
                    var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("dashboard", "account");
                    }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    return RedirectToAction("index", "home");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user Id = {userId} is invalid";
                return View("NotFound");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }

        [HttpGet]
        [Authorize]
        public async Task<ViewResult> Dashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser user = await userManager.FindByIdAsync(userId);
            return View(new DashboardViewModel
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneConfirmed = user.PhoneNumberConfirmed
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        protected void SendMail(string email, string subject, string content)
        {
            mailService.Send(new EmailMessage
            {
                ToAddresses = new List<EmailAddress>
                         {
                             new EmailAddress
                             {
                                  Name= email,
                                  Address = email
                             }
                         },
                FromAddresses = new List<EmailAddress>
                         {
                             new EmailAddress
                             {
                                 Name = "Admin",
                                 Address = "no@reply.gmail.com"
                             }
                         },
                Subject = subject,
                Content = content
            });
        }
    }
}
