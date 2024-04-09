using DotnetPipelineApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetPipelineApp.Models;

using Moq;
using Xunit;

namespace DotnetPipelineApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Sets_Message_In_ViewBag()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hey , This is Aparna Joshi", result.ViewData["Message"]);
        }

        [Fact]
        public void Privacy_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Privacy();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Error();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_Passes_ErrorViewModel_To_View()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.NotNull(result); // Ensure that the result is not null
            Assert.IsType<ErrorViewModel>(result.Model);
        }
    }
}
