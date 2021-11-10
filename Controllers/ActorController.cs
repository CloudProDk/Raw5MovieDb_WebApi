using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using Raw5MovieDb_WebApi.ViewModels;
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
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public ActorController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            IList<Actor> actors = _dataService.GetActors();
            var model = actors.Select(GetActorViewModel);
            return Ok(model);
        }

        [HttpGet("{nconst}", Name = nameof(GetActor))]
        public IActionResult GetActor(string nconst)
        {
            Actor actor = _dataService.GetActor(nconst);
            var model = GetActorViewModel(actor);
            return Ok(model);
        }

        //[HttpGet("search")]
        //public IActionResult FindActor([FromQuery] string q = "")
        //{
        //    if (q == null || q == "")
        //    {
        //        return new JsonResult(new EmptyResult());
        //    }

        //    IList<Actor> actors = _dataService.FindActor(q);

        //    var model = actors.Select(GetActorViewModel);
        //    return Ok(model);
        //}

        private ActorViewModel GetActorViewModel(Actor actor)
        {
            var model = _mapper.Map<ActorViewModel>(actor);
            model.Url = GetUrl(actor);
            return model;
        }

        private string GetUrl(Actor actor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActor), new { actor.Nconst });
        }
    }
}
