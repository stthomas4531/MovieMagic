using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMagic.Models;


namespace MovieMagic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
         private static readonly Movie[] mockMovies = new[]
        {
            new Movie {MovieId = 1, Name = "Cars", Rating = 4 },
            new Movie {MovieId = 2, Name = "Jurassic Park", Rating = 5 },
            new Movie {MovieId = 3, Name = "Back To The Future", Rating = 5 }
        };

        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
           return mockMovies;
        }

        [HttpGet, Route("{MovieId:int}")]
        public Movie GetMoviebyId(int movieId)
        {
            var movie = mockMovies.FirstOrDefault(m => m.MovieId == movieId);
            if (movie == null) {
                Response.StatusCode = (int) HttpStatusCode.NotFound;
                return null;

            }
           return movie;
        }
    }
}
