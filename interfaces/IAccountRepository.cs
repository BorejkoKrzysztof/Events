using Events.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Events.interfaces
{
    public interface IAccountRepository
    {
        string CalculateAge(DateTime birtday);

        void CreateAccount(Account account);

        ClaimsPrincipal GetClaims(Account account);
    }
}
