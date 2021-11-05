using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
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

        public TitleController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetTitles()
        {
            IList<Title> titles = _dataService.GetTitles();
            //var model = titles.Select(Title);
            return Ok(titles);
        }

        [HttpGet("{tconst}")]
        public IActionResult GetTitle(string tconst)
        {
            Title title = _dataService.GetTitle(tconst);
            return Ok(title);
        }

        [HttpGet("popular")]
        public IActionResult GetPopularTitles()
        {
            IList<Title> titles = _dataService.GetPopularTitles();
            return Ok(titles);
        }
    }
}
