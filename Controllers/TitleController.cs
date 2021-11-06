using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/titles")]
    [ApiController]
    public class TitleController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public TitleController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTitles()
        {
            IList<Title> titles = _dataService.GetTitles();
            var model = titles.Select(CreateTitleViewModel);
            return Ok(model);
        }

        [HttpGet("{tconst}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string tconst)
        {
            Title title = _dataService.GetTitle(tconst);

            if (title == null)
            {
                return NotFound();
            }

            var model = CreateTitleViewModel(title);
            return Ok(model);
        }

        [HttpGet("popular")]
        public IActionResult GetPopularTitles()
        {
            IList<Title> titles = _dataService.GetPopularTitles();
            return Ok(titles);
        }

        [HttpGet("search")]
        public IActionResult FindTitle([FromQuery] string q = "")
        {
            if (q == null || q == "")
            {
                return new JsonResult(new EmptyResult());
            }

            IList<Title> titles = _dataService.FindTitle(q);

            var model = titles.Select(CreateTitleViewModel);
            return Ok(model);
        }

        private TitleViewModel CreateTitleViewModel(Title title)
        {
            var model = _mapper.Map<TitleViewModel>(title);
            model.Url = GetUrl(title);
            return model;
        }

        private string GetUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitle), new { title.Tconst });
        }
    }
}
