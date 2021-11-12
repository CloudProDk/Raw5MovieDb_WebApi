using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper; public UserController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_dataService.GetAllUsers());
        }

        [HttpGet("{uconst}")]
        public IActionResult GetUser(string uconst)
        {   
            var user = _dataService.GetUser(uconst);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromQuery] CreateUserAccountViewModel newUser)
        {
            var _user = new CreateUserAccountViewModel
            {
                Email = newUser.Email,
                UserName = newUser.UserName,
                Password = newUser.Password,
                Birthdate = newUser.Birthdate
            };
            return Created(nameof(GetUser), _dataService.RegisterUser(_user));
        }
    }
}