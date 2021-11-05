using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;


namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("[controller]")]
    public class Authentication : Controller
    {
        //Dependency injected service
        private IAuthenticationService _authenticationService;
        public Authentication(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAccount model)
        {
            var user = _authenticationService.Authenticate(model.UserName, model.Password);

            if (user == null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            } 

            return Ok(user);
        }
    }
}