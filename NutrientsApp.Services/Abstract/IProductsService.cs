using System;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IProductsService
    {
        void AddProduct(Product ingredient);
        void UpdateProduct(Product ingredient);
        Product GetProductById(Guid id);
        void DeleteProductById(Guid id);
    }
}
