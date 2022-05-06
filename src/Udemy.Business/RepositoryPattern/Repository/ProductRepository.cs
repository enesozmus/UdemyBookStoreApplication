﻿using Udemy.Business.RepositoryPattern.IRepository;
using Udemy.DataAccess.Context;
using Udemy.Models.Entities;

namespace Udemy.Business.RepositoryPattern.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbcontex;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _dbcontex = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _dbcontex.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
