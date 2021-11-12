using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public GenreController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{genreId}", Name = nameof(GetGenre))]
        public IActionResult GetGenre(int genreId)
        {
            Genre genre = _dataService.GetGenre(genreId);

            if (genre == null)
            {
                return NotFound();
            }

            var model = GetGenreViewModel(genre);
            return Ok(model);
        }

        private GenreViewModel GetGenreViewModel(Genre genre)
        {
            var model = _mapper.Map<GenreViewModel>(genre);
            model.Url = GetGenreUrl(genre);
            return model;
        }

        private string GetGenreUrl(Genre genre)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetGenre), new { genre.Id });
        }
    }
}
