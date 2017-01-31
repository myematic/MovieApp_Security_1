using MyMovieApp_Security.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieApp_Security.Models
{
    public class EFRepository : IDisposable,IRepository
    {
        private ApplicationDbContext _db;
        public EFRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IList<Movie> ListMovies()
        {
            return _db.Movies.ToList();
        }

        public Movie FindMovie(int id)
        {
            return _db.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void CreateMovie(Movie movieToCreate)
        {
            _db.Movies.Add(movieToCreate);
            _db.SaveChanges();
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            var originalMovie = this.FindMovie(movieToUpdate.Id);
            originalMovie.Title = movieToUpdate.Title;
            originalMovie.Director = movieToUpdate.Director;
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var originalMovie = this.FindMovie(id);
            _db.Movies.Remove(originalMovie);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }





}

