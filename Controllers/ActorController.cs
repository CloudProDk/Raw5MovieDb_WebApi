using Microsoft.AspNetCore.Mvc;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IDataService _dataService;

        public ActorController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetTitles()
        {
            IList<Actor> actors = _dataService.GetActors();
            return Ok(actors);
        }

        [HttpGet("{nconst}")]
        public IActionResult GetTitle(string nconst)
        {
            Actor actor = _dataService.GetActor(nconst);
            return Ok(actor);
        }
    }
}
