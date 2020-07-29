using smart_family_backend.Contracts.V1.Requests;
using smart_family_backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_family_backend.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest user);
        Task<AuthenticationResult> LoginAsync(UserLoginRequest user);
    }
}
