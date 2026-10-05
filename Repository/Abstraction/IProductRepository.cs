using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IProductRepository
    {
        void AddProduct(Product productToAdd);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool DeleteProduct(int id);
        Product UpdateProduct(Product productToUpdate);



    }
}
