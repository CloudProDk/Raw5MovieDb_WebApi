using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raw5MovieDb_WebApi.Services;

namespace Raw5MovieDb_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserBookmarkController : ControllerBase
    {
        private readonly IDataService _dataService;
        public UserBookmarkController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Returns all bookmarks for a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [HttpGet("{uconst}")]
        public IActionResult GetBookmarks(string uconst)
        {
            //TODO need get user bookmarks
            return Ok();
        }

        /// <summary>
        /// Adds a new bookmark
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="tconst"></param>
        /// <returns></returns>
        [HttpPost("{uconst}")]
        public IActionResult CreateBookmark(string uconst, string tconst)
        {
            //TODO need get user bookmarks
            return Ok();
        }

        /// <summary>
        /// Deletes a bookmark
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="tconst"></param>
        /// <returns></returns>
        [HttpDelete("{uconst}")]
        public IActionResult DeleteBookmark(string uconst, string tconst)
        {
            //TODO need get user bookmarks
            return Ok();
        }



    }
}