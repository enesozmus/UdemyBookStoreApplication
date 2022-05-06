using Udemy.Business.RepositoryPattern.IRepository;
using Udemy.DataAccess.Context;
using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbcontex;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _dbcontex = db;
        }

        public void Update(Category obj)
        {
            _dbcontex.Categories.Update(obj);
        }
    }
}
