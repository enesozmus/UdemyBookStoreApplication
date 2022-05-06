﻿using Udemy.Business.RepositoryPattern.IRepository;

namespace Udemy.Business
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        //IShoppingCartRepository ShoppingCart { get; }
        //IApplicationUserRepository ApplicationUser { get; }
        //IOrderDetailRepository OrderDetail { get; }
        //IOrderHeaderRepository OrderHeader { get; }
        void Save();
    }
}
