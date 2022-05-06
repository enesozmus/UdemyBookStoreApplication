using Udemy.Business.RepositoryPattern.IRepository;
using Udemy.DataAccess.Context;
using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _dbcontex;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _dbcontex = db;
        }

        public void Update(Company obj)
        {
            _dbcontex.Companies.Update(obj);
        }
    }
}
