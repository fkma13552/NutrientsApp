using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Entities;
using NutrientsApp.Services;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.UnitTests
{
    public class ProductNutrientsTestService
    {
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task TestGetProductNutrients_Success()
        {
            //Arrange
            SetupTestGetProductNutrients(WithNutrientsDictionary(), WithNutrientsNames());
            
            //Act
            IProductNutrientsService productNutrientsService = WithService();
            var result = await 
                productNutrientsService.GetProductNutrients(Guid.NewGuid());
            
            //Assert
            result.Should().HaveCount(3);
            result.Should().ContainKey("Proteins");
            result.Should().ContainKey("Fats");
            result.Should().ContainKey("Carbohydrates");
        }

        [TearDown]
        public void TearDown()
        {
            _unitOfWork.Verify();
        }


        #region Setup

        private void SetupTestGetProductNutrients(IDictionary<string, int> productNutrientsDictionary, IList<string> nutrientsNames)
        {
            _unitOfWork
                .Setup(a => a.ProductNutrientsRepository
                .GetProductNutrients(It.IsAny<Guid>()))
                .ReturnsAsync(productNutrientsDictionary)
                .Verifiable();
            _unitOfWork
                .Setup(a => a.NutrientComponentsRepository.GetAllComponentsNames())
                .ReturnsAsync(nutrientsNames)
                .Verifiable();
        }

        #endregion

        #region With

        private ProductNutrientsService WithService()
        {
            return new ProductNutrientsService(_unitOfWork.Object);
        }

        private IDictionary<string, int> WithNutrientsDictionary()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("Proteins", 20);
            dictionary.Add("Carbohydrates", 40);
            return dictionary;
        }

        private IList<ProductNutrientEntity> WithListProductNutrient()
        {
            var productNutrientEntities = new List<ProductNutrientEntity>();
            productNutrientEntities.Add(new ProductNutrientEntity() {
                Id = new Guid("d2812057-97b3-4e8e-b1b4-1fc7adf09d19"),
                ProductId = new Guid("a2b90f82-5b72-4411-882e-34dbb0bfbb8e"), 
                NutrientId = new Guid("05fc2dd3-b621-49b5-8718-864e2f0de20f"),
                AmountPerHundred = 30});
            productNutrientEntities.Add(new ProductNutrientEntity() {
                Id = new Guid("f9ba6701-19cc-4189-91f7-81d740dcd7b4"),
                ProductId = new Guid("a2b90f82-5b72-4411-882e-34dbb0bfbb8e"), 
                NutrientId = new Guid("3398ebbe-63aa-4e46-8f7e-7b5f3aeabb25"),
                AmountPerHundred = 20});
            productNutrientEntities.Add(new ProductNutrientEntity() {
                Id = new Guid("4d4c5980-080a-4b32-b948-f4c014556a61"),
                ProductId = new Guid("a2b90f82-5b72-4411-882e-34dbb0bfbb8e"), 
                NutrientId = new Guid("9ee30df1-1ff4-47dd-92b2-71aa6945b50d"),
                AmountPerHundred = 40});
            return productNutrientEntities;
        }

        private IList<string> WithNutrientsNames()
        {
            IList<string> names = new List<string>();
            names.Add("Proteins");
            names.Add("Carbohydrates");
            names.Add("Fats");
            return names;
        }

        #endregion
    }
}