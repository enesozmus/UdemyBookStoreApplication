using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}
