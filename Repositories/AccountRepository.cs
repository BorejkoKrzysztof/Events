using Events.Database;
using Events.Entities;
using Events.interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Events.services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EventDbContext _dbContext;

        public AccountRepository(EventDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public string CalculateAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age))
                age--;

            return age.ToString();
        }

        public void CreateAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public ClaimsPrincipal GetClaims(Account account)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, account.EmailAdress));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, account.Role.ToString()));
            claims.Add(new Claim("Age", this.CalculateAge(account.AccountOwner.DateOfBirth)));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsprincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsprincipal;
        }
    }
}
