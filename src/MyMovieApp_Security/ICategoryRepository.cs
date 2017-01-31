using System.Collections.Generic;

namespace MyMovieApp_Security.Models
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category categoryToCreate);
        void DeleteCategory(int id);
        void Dispose();
        Category FindCategory(int id);
        IList<Category> ListCategorires();
        void UpdateCategory(Category categoryToUpdate);
    }
}