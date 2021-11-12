using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raw5MovieDb_WebApi.Services;

namespace Raw5MovieDb_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchHistoryController : Controller
    {
        private readonly IDataService _dataService;
        public SearchHistoryController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Returns searchhistory for a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [HttpGet("{uconst}")]
        public IActionResult GetSearchHistory(string uconst)
        {
            //TODO need get user search history
            return Ok();
        }
        
        /// <summary>
        /// Adds a searchhistory entry in the database
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="tconst"></param>
        /// <param name="searchParam"></param>
        /// <returns></returns>
        [HttpPost("{uconst}")]
        public IActionResult CreateSearchHistoryEntry(string uconst, string tconst, string searchParam)
        {
            //TODO need get user bookmarks
            return Ok();
        }
    }
}