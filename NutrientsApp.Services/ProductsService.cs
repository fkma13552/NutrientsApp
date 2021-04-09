using System;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Data.UnitOfWork.Abstract;
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

        public Product GetProductById(Guid id)
        {
            return _unitOfWork.ProductsRepository.GetById(id).ToDomain();
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.ProductsRepository.Update(product.ToEntity());
        }
    }
}
