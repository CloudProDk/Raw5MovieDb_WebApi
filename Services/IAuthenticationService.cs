using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IAuthenticationService
    {
        User Authenticate(string userName, string password);
    }
}