using System;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Entities;
using NutrientsApp.Mappers;

namespace NutrientsApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProduct(Product product)
        {
            _unitOfWork.ProductsRepository.Create(product.ToEntity());
        }

        public void DeleteProductById(Guid id)
        {
            _unitOfWork.ProductsRepository.DeleteById(id);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var prod = await _unitOfWork.ProductsRepository.GetById(id);
                return prod.ToDomain();
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.ProductsRepository.Update(product.ToEntity());
        }
    }
}
