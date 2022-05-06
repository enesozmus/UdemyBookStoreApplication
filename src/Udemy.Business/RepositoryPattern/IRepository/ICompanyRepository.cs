using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
