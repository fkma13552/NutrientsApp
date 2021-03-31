using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NutrientsApp.Data.Repositories
{
    public class ProductsRepository : IProductsRepository<ProductEntity>
    {

        public static IDictionary<Guid, ProductEntity> _productData;

        public ProductsRepository()
        {
            if (_productData == null)
            {
                _productData = new Dictionary<Guid, ProductEntity>();

                ProductEntity eggs = new ProductEntity
                {
                    Id = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    Name = "Eggs",
                    Proteins = 13,
                    Fats = 12,
                    Carbohydrates = 1,
                    Vitamins = 1,
                    Minerals = 1,
                };
                ProductEntity celery = new ProductEntity
                {
                    Id = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    Name = "Celery",
                    Proteins = 1,
                    Fats = 1,
                    Carbohydrates = 2,
                    Vitamins = 1,
                    Minerals = 1
                };
                ProductEntity mayonnaise = new ProductEntity
                {
                    Id = new Guid("a95306b8-3e47-419e-95b2-b46da6043cd6"),
                    Name = "Mayonnaise",
                    Proteins = 13,
                    Fats = 75,
                    Carbohydrates = 1,
                    Vitamins = 1,
                    Minerals = 1
                };
                ProductEntity chicken = new ProductEntity
                {
                    Id = new Guid("8b3c2722-cf42-4d53-846d-c48bbd2f7f9f"),
                    Name = "Chicken",
                    Proteins = 13,
                    Fats = 12,
                    Carbohydrates = 1,
                    Vitamins = 1,
                    Minerals = 1
                };
                ProductEntity ham = new ProductEntity
                {
                    Id = new Guid("1bfdd3e3-5557-449f-b6c5-edd185d35fe0"),
                    Name = "Ham",
                    Proteins = 13,
                    Fats = 12,
                    Carbohydrates = 1,
                    Vitamins = 1,
                    Minerals = 1
                };
                ProductEntity cheese = new ProductEntity
                {
                    Id = new Guid("91af8060-6a1d-4f79-86c9-1cb7ff2e34c2"),
                    Name = "Cheese",
                    Proteins = 25,
                    Fats = 30,
                    Carbohydrates = 1,
                    Vitamins = 1,
                    Minerals = 1
                };
                ProductEntity crackers = new ProductEntity
                {
                    Id = new Guid("f633cd9b-2714-48ff-a22d-bd3eb048eb08"),
                    Name = "Cracker",
                    Proteins = 20,
                    Fats = 20,
                    Carbohydrates = 1,
                    Vitamins = 1,
                    Minerals = 1
                };
                Create(eggs);
                Create(celery);
                Create(mayonnaise);
                Create(chicken);
                Create(ham);
                Create(cheese);
                Create(crackers);
            }
        }


        public void Create(ProductEntity entity)
        {
            _productData.Add(entity.Id, entity);
        }

        public void Update(ProductEntity entity)
        {
            _productData[entity.Id] = entity;
        }

        public ProductEntity GetById(Guid id)
        {
            return _productData[id];
        }

        public void DeleteById(Guid id)
        {
            _productData.Remove(id);
        }

        public IList<ProductEntity> GetAll()
        {
            return _productData.Values.ToList();
        }
        
    }
}
