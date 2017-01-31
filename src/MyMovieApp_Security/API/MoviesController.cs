using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp_Security.Data;
using MyMovieApp_Security.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMovieApp_Security.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class MoviesController : Controller
    {
        private IRepository _repo;
        public MoviesController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            
            return _repo.ListMovies();
        }

        [HttpGet]
        [Route("/api/movies/search/{title}")]
        public IEnumerable<Movie> fetch(string title)
        {
            return _repo.ListMovies().Where(m => m.Title.Contains(title)).ToList();
        }




        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _repo.FindMovie(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (movie.Id == 0)
            {
                _repo.CreateMovie(movie);
            }
            else
            {
                _repo.UpdateMovie(movie);
            }
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteMovie(id);
            return Ok();
        }
    }
}

