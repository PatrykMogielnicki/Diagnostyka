using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Domain.Entities;
using Diagnostyka.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Diagnostyka.Application.UnitTests.Controllers
{
    public class ItemControllerTest
    {
        [Fact]
        public void Constructor_Create_With_DependencyInjection()
        {
            //Arrange
            var moq = new Mock<IItemManager>();
            //Act
            var sut = new ItemController(moq.Object);
            //Assert
            sut.Should().BeAssignableTo<ItemController>();
        }

        [Fact]
        public void Get_Use_GetAll_Once()
        {
            //Arrange
            var moq = new Mock<IItemManager>();
            var controller = new ItemController(moq.Object);
            //Act
            controller.Get();
            //Assert
            moq.Verify(context => context.GetAll(),Times.Once);
        }

        [Fact]
        public void Get_Always_Return_Array()
        {
            //Arrange
            var moq = new Mock<IItemManager>();
            var controller = new ItemController(moq.Object);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().BeOfType<List<Item>>();
        }

        [Theory]
        [InlineData(0)]
        public void GetID_Return_BadRequest_If_GetById_Dont_Return_Item(int value)
        {
            //Arrange
            var moq = new Mock<IItemManager>();
            moq.Setup(set => set.GetById(0));
            var controller = new ItemController(moq.Object);
            //Act
            var result = controller.Get(value);
            //Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }      
    }
}
