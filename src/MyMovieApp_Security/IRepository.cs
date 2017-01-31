using System.Collections.Generic;

namespace MyMovieApp_Security.Models
{
    public interface IRepository
    {
        void CreateMovie(Movie movieToCreate);
        void DeleteMovie(int id);
        void Dispose();
        Movie FindMovie(int id);
        IList<Movie> ListMovies();
        void UpdateMovie(Movie movieToUpdate);
    }
}