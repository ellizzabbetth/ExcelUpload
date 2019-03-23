using FileUpload.Contracts;
using FileUpload.Controllers.api;
using FileUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace web_api_tests
{
    public class DataControllerTest
    {
        DataController _controller;
        IDataService _service;


        public DataControllerTest()
        {
            _service = new DataServiceFake();
            _controller = new DataController(_service);
        }

        [Fact]
        public void ShowData_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.ShowData();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

    }
}
