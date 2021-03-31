using System;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;
using NutrientsApp.Mappers;

namespace NutrientsApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository<ProductEntity> _productsRepository;

        public ProductsService(IProductsRepository<ProductEntity> productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public void AddProduct(Product product)
        {
            _productsRepository.Create(product.ToEntity());
        }

        public void DeleteProductById(Guid id)
        {
            _productsRepository.DeleteById(id);
        }

        public Product GetProductById(Guid id)
        {
            return _productsRepository.GetById(id).ToDomain();
        }

        public void UpdateProduct(Product product)
        {
            _productsRepository.Update(product.ToEntity());
        }
    }
}
