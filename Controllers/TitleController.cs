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

        [HttpGet(Name = nameof(GetTitles))]
        public IActionResult GetTitles([FromQuery] QueryString queryString)
        {
            IList<Title> titles = _dataService.GetTitles(queryString);
            var model = titles.Select(GetTitleViewModel);
            var response = CreateResponseObj(model, queryString, _dataService.TitlesCount());
            return Ok(response);
        }

        [HttpGet("{tconst}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string tconst)
        {
            Title title = _dataService.GetTitle(tconst);

            if (title == null)
            {
                return NotFound();
            }

            var model = GetTitleViewModel(title);
            model.GenreList = title.Genres.Select(x => GetGenreViewModel(x.Genre)).ToList();
            return Ok(model);
        }

        [HttpGet("similar/{tconst}")]
        public IActionResult GetSimilar(string tconst)
        {
            IList<Title> titles = _dataService.FindSimilarSearch(tconst);

            if (titles == null)
            {
                return NotFound();
            }

            var model = titles.Select(GetTitleViewModel);
            return Ok(model);
        }

        [HttpGet("popular")]
        public IActionResult GetPopularTitles()
        {
            IList<Title> titles = _dataService.GetPopularTitles();
            var model = titles.Select(GetTitleViewModel);
            return Ok(model);
        }

        [HttpGet("search")]
        public IActionResult FindTitle([FromQuery] QueryString queryString)
        {
            if (queryString.SearchQuery == null || queryString.SearchQuery == "")
            {
                return new JsonResult(new EmptyResult());
            }

            IList<Title> titles = _dataService.StringSearch(queryString.SearchQuery, "1");

            var model = titles.Select(GetTitleViewModel);
            return Ok(model);
        }

        [HttpGet("searchadv")]
        public IActionResult FindTitleAdv([FromQuery] QueryString queryString)
        {
            if (queryString.SearchQuery == null || queryString.SearchQuery == "")
            {
                return new JsonResult(new EmptyResult());
            }

            string[] words = { queryString.SearchQuery };
            IList<Title> titles = _dataService.WordToWord(words);

            var model = titles.Select(GetTitleViewModel);
            return Ok(model);
        }

        [HttpGet("{tconst}/actors", Name = nameof(GetTitleActors))]
        public IActionResult GetTitleActors(string tconst)
        {
            IList<Actor> actors = _dataService.GetPopularActorsRankedByTitle(tconst);

            var model = actors.Select(GetActorViewModel);
            return Ok(model);
        }

        /*
         *
         * Helper methods
         *
         */

        private object CreateResponseObj(IEnumerable<TitleViewModel> model, QueryString queryString, int total)
        {
            return new
            {
                total,
                previousPage = CreatePreviousPageLink(queryString),
                currentPage = CreateCurrentPageLink(queryString),
                nextPage = CreateNextPageLink(queryString, total),
                results = model
            };
        }

        private string CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetTitlesUrl(queryString.Page + 1, queryString.PageSize);
        }

        private string CreateCurrentPageLink(QueryString queryString)
        {
            return GetTitlesUrl(queryString.Page, queryString.PageSize);
        }

        private string CreatePreviousPageLink(QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetTitlesUrl(queryString.Page - 1, queryString.PageSize);
        }

        private string GetTitlesUrl(int page, int pageSize)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitles), new { page, pageSize });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private TitleViewModel GetTitleViewModel(Title title)
        {
            var model = _mapper.Map<TitleViewModel>(title);
            model.Url = GetTitleUrl(title);
            model.Actors = GetTitleActorsUrl(title);
            model.ImdbRating = GetTitleRatingViewModel(title.TitleRating);
            return model;
        }

        private TitleRatingViewModel GetTitleRatingViewModel(TitleRating titleRating)
        {
            var model = _mapper.Map<TitleRatingViewModel>(titleRating);
            return model;
        }

        private GenreViewModel GetGenreViewModel(Genre genre)
        {
            var model = _mapper.Map<GenreViewModel>(genre);
            model.Url = GetGenreUrl(genre);
            return model;
        }

        private string GetTitleUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitle), new { Tconst = title.Tconst.TrimEnd() });
        }

        private string GetGenreUrl(Genre genre)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GenreController.GetGenre), new { GenreId = genre.Id });
        }

        private ActorViewModel GetActorViewModel(Actor actor)
        {
            var model = _mapper.Map<ActorViewModel>(actor);
            model.Url = GetActorUrl(actor);
            return model;
        }

        private string GetActorUrl(Actor actor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(ActorController.GetActor), new { Nconst = actor.Nconst.TrimEnd() });
        }

        private string GetTitleActorsUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitleActors), new { Tconst = title.Tconst.TrimEnd() });
        }
    }
}
