using Udemy.Business.RepositoryPattern.IRepository;
using Udemy.DataAccess.Context;
using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _dbcontex;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _dbcontex = db;
        }

        public void Update(CoverType obj)
        {
            _dbcontex.CoverTypes.Update(obj);
        }
    }
}
