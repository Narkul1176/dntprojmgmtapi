using DAL.Entities;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context;
        private readonly ICustom _custom;

        public ProductRepository(AppDbContext context, ICustom custom)
        {
            _context = context;
            _custom = custom;

            _custom.Increment();
        }
        public void AddProduct(Product productToAdd)
        {
            _context.Products.Add(productToAdd);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var productToDelete = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Product> GetAllProducts()
        {
            var products = (from p in _context.Products
                            select p).ToList();
            //var products = _context.Products.ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return product;
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            _context.Entry<Product>(productToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return productToUpdate;
        }
    }
}
