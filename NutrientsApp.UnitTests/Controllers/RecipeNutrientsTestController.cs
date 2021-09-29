using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NutrientsApp.Services.Abstract;
using NutrientsApp.WebApi.Controllers;

namespace NutrientsApp.UnitTests
{
    public class RecipeNutrientsTestController
    {
        private Mock<IRecipesService> _recipesService;

        [SetUp]
        public void Setup()
        {
            _recipesService = new Mock<IRecipesService>();
        }

        [Test]
        public async Task TestGetFromMultiple_Success()
        {
            //Arrange
            SetupGetRecipeNutrients(WithNutrientsDictionary());
            
            //Act
            var controller = WithRecipeNutrientsController();
            var result = await controller.GetFromMultiple(WithNotEmptyGuids()) as OkObjectResult;
            
            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        
        [Test]
        public async Task TestGetFromMultiple_Fail_EmptyIds()
        {
            //Arrange
          
            
            //Act
            var controller = WithRecipeNutrientsController();
            var result = await controller.GetFromMultiple(WithEmptyGuids()) as BadRequestResult;
            
            //Assert
            
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);

        }
        
        [Test]
        public async Task TestGetFromMultiple_Fail_NoIds()
        {
            //Arrange
          
            
            //Act
            var controller = WithRecipeNutrientsController();
            var result = await controller.GetFromMultiple(WithNoGuids()) as BadRequestResult;
            
            //Assert
            
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);

        }

        [TearDown]
        public void TearDown()
        {
            _recipesService.Verify();
        }
        
        #region Setup

        private void SetupGetRecipeNutrients(IDictionary<string, int> dictionary)
        {
            _recipesService
                .Setup(s => s.GetRecipeNutrients(It.IsAny<Guid>()))
                .ReturnsAsync(dictionary)
                .Verifiable();
        }
        
        #endregion

        #region With

        private IDictionary<string, int> WithNutrientsDictionary()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("Fats", 60);
            dictionary.Add("Carbohydrates", 40);
            dictionary.Add("Proteins", 30);
            return dictionary;
        }

        private RecipeNutrientsController WithRecipeNutrientsController()
        {
            return new RecipeNutrientsController(_recipesService.Object);
        }

        private Guid[] WithNotEmptyGuids()
        {
            return new[] {Guid.NewGuid() };
        }
        
        private Guid[] WithNoGuids()
        {
            return new Guid[] {};
        }
        
        private Guid[] WithEmptyGuids()
        {
            return new Guid[] {Guid.Empty};
        }
        
        //AsyncControllerActionInvoker
        #endregion
    }
}