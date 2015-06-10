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
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDemoContext _context = new ProductDemoContext();

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.Select(x => x);
        }

        public Product GetById(int id)
        {
            return _context.Product.FirstOrDefault(x => x.ProductId == id);
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            return _context.Product.FirstOrDefault(expression);
        }

        public IQueryable<Product> GetMany(Expression<Func<Product, bool>> expression)
        {
            return _context.Product.Where(expression);
        }

        public void Insert(Product obj)
        {
            _context.Product.Add(obj);
        }

        public void Update(Product obj)
        {
            _context.Product.AddOrUpdate(obj);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Product.Remove(entity);
            }
        }

        public int Count()
        {
            return _context.Product.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
