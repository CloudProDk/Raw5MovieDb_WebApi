using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("[controller]")]
    public class User : Controller
    {    
        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser([FromBody] UserAccount model)
        {
            var newUser = new UserAccount
            {
                Uconst = 10,  //Db context should contain a way to get max uconst and return max(uconst) + 1
                UserName = model.UserName,
                Email = model.Email,
                Birthdate = new DateTime(1986-10-04),
                Password = model.Password,
            };

            return Created(nameof(RegisterUser), newUser) /*ds.RegisterUser(newUser)*/;
        }


    }
}