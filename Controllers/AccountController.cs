using AutoMapper;
using Events.Database;
using Events.Entities;
using Events.interfaces;
using Events.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Events.Controllers
{
    public class AccountController : Controller
    {
        private readonly EventDbContext _dbContext;
        private readonly IPasswordHasher<Account> _hasher;
        private readonly IAccountRepository _service;
        private readonly IMapper _mapper;

        public AccountController(EventDbContext dbContext, IPasswordHasher<Account> hasher, IAccountRepository service, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._hasher = hasher;
            this._service = service;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string returnURL)
        {
            if (_dbContext.Accounts.Any(r => r.EmailAdress == email))
            {
                var acc = _dbContext.Accounts.FirstOrDefault(r => r.EmailAdress == email);
                if (_hasher.VerifyHashedPassword(acc, acc.PasswordHash, password) == PasswordVerificationResult.Success)
                {
                    //var claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.Email, acc.EmailAdress));
                    //claims.Add(new Claim(ClaimTypes.NameIdentifier, acc.Id.ToString()));
                    //claims.Add(new Claim(ClaimTypes.Role, acc.Role.ToString()));
                    //claims.Add(new Claim("Age", _service.CalculateAge(acc.AccountOwner.DateOfBirth)));
                    //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var claimsprincipal = new ClaimsPrincipal(claimsIdentity);

                    var claimsPrincipal = _service.GetClaims(acc);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    return Redirect(returnURL);
                }
                string passwordOrLoginError = "Nieprawidłowe hasło lub login";
                return View(passwordOrLoginError);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterInfoDTO registerinfo)
        {
            if (ModelState.IsValid)
            {
                if (!_dbContext.Accounts.Any(r => r.EmailAdress == registerinfo.Email))
                {

                    var registeringAccount = _mapper.Map<Account>(registerinfo); // trzeba zrobić mapowanie
                    _service.CreateAccount(registeringAccount);

                    //var claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.Email, registeringAccount.EmailAdress));
                    //claims.Add(new Claim(ClaimTypes.NameIdentifier, _dbContext.Accounts
                    //                .FirstOrDefault(r => r.EmailAdress == registeringAccount.EmailAdress).Id
                    //                .ToString()));
                    //claims.Add(new Claim(ClaimTypes.Role, registeringAccount.Role.ToString()));
                    //claims.Add(new Claim("Age", _service.CalculateAge(registeringAccount.AccountOwner.DateOfBirth)));
                    //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var claimsprincipal = new ClaimsPrincipal(claimsIdentity);

                    var claimsPrincipal = _service.GetClaims(_dbContext.Accounts.FirstOrDefault(r => r.EmailAdress == registerinfo.Email));
                    await HttpContext.SignInAsync(claimsPrincipal);
                }
                else
                {
                    // ze istnieje juz taki email
                }

                return RedirectToAction();
            }

            return View();
        }
    }
}
