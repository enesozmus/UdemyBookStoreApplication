using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
