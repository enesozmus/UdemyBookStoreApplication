using Udemy.Business.RepositoryPattern.IRepository;
using Udemy.Business.RepositoryPattern.Repository;
using Udemy.DataAccess.Context;

namespace Udemy.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbcontext;

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            Category = new CategoryRepository(_dbcontext);
            CoverType = new CoverTypeRepository(_dbcontext);
            Product = new ProductRepository(_dbcontext);
            Company = new CompanyRepository(_dbcontext);
            //ApplicationUser = new ApplicationUserRepository(_dbcontext);
            //ShoppingCart = new ShoppingCartRepository(_dbcontext);
            //OrderHeader = new OrderHeaderRepository(_dbcontext);
            //OrderDetail = new OrderDetailRepository(_dbcontext);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        //public IShoppingCartRepository ShoppingCart { get; private set; }
        //public IApplicationUserRepository ApplicationUser { get; private set; }
        //public IOrderHeaderRepository OrderHeader { get; private set; }
        //public IOrderDetailRepository OrderDetail { get; private set; }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
