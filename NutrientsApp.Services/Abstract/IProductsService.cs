using System;
using System.Threading.Tasks;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IProductsService
    {
        void AddProduct(Product ingredient);
        void UpdateProduct(Product ingredient);
        Task<Product> GetProductById(Guid id);
        void DeleteProductById(Guid id);
    }
}
