using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
