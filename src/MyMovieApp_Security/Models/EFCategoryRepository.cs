using MyMovieApp_Security.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieApp_Security.Models
{
    public class EFCategoryRepository : IDisposable, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public EFCategoryRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IList<Category> ListCategorires()
        {
            return _db.Categories.ToList();
        }

        public Category FindCategory(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.CategoryID == id);
        }

        public void CreateCategory(Category categoryToCreate)
        {
            _db.Categories.Add(categoryToCreate);
            _db.SaveChanges();
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            var originalCategory = this.FindCategory(categoryToUpdate.CategoryID);
            originalCategory.Name = categoryToUpdate.Name;
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var originalCategory = this.FindCategory(id);
            _db.Categories.Remove(originalCategory);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }



    }
}
