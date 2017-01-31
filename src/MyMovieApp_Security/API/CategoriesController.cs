using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp_Security.Data;
using MyMovieApp_Security.Models;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMovieApp.API
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _db;
        public List<Movie> movieList;

        public CategoriesController(ApplicationDbContext db)
        {
            this._db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _db.Categories.Include(c => c.Movies).ToList();



            return categories;
        }

        // GET api/category/Categoryname
        [HttpGet("{name}")]
        public IActionResult GetSpecific(string name)
        {
            var movie = _db.Categories.Include(c => c.Movies).Where(c => c.Name == name).ToList();
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        /* var category = _db.Categories.FirstOrDefault(c => c.Name == "Drama");
         if (category == null)
         {
             return NotFound();
         }
         return Ok(category);*/

        /*var dramas = _db.Categories.Include(c => c.Movies).Where(c => c.Name == "Drama").ToList();
        if (dramas == null)
        {
            return NotFound();
        }
        return Ok(dramas);*/



        // GET api/category/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            //categorie.Movies = (ICollection<Movie>)_db.Movies.Where(m => m.CategoryID == categorie.CategoryID);
            return Ok(category);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (category.CategoryID == 0)
            {
                // add category
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            else
            {
                // update category
                var original = _db.Categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
                original.Name = category.Name;
                original.Movies = category.Movies;
                _db.SaveChanges();
            }
            return Ok(category);




        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var category = _db.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return Ok();



        }
    }
}
