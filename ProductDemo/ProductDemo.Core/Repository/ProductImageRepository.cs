using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using ProductDemo.Core.Infrastructure;
using ProductDemo.Data.DataContext;
using ProductDemo.Data.Model;

namespace ProductDemo.Core.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ProductDemoContext _context = new ProductDemoContext();

        public IEnumerable<ProductImage> GetAll()
        {
            return _context.ProductImage.Select(x => x);
        }

        public ProductImage GetById(int id)
        {
            return _context.ProductImage.FirstOrDefault(x => x.ProductImageId == id);
        }

        public ProductImage Get(Expression<Func<ProductImage, bool>> expression)
        {
            return _context.ProductImage.FirstOrDefault(expression);
        }

        public IQueryable<ProductImage> GetMany(Expression<Func<ProductImage, bool>> expression)
        {
            return _context.ProductImage.Where(expression);
        }

        public void Insert(ProductImage obj)
        {
            _context.ProductImage.Add(obj);
        }

        public void Update(ProductImage obj)
        {
            _context.ProductImage.AddOrUpdate(obj);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.ProductImage.Remove(entity);
            }
        }

        public int Count()
        {
            return _context.ProductImage.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
