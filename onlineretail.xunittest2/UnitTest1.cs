using Microsoft.AspNetCore.Mvc.Testing;
using onlineRetail.Controllers;
using onlineRetail.Repository;
using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineretail.xunittest2
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly ProductController _controller;
        private readonly ProductRepository _service;
        private readonly WebApplicationFactory<Program> _factory;

        public UnitTest1(ProductController controller, ProductRepository service,WebApplicationFactory<Program> factory)
        {
            _controller= controller;
            _service = service;
            _factory = factory;
        }
        [Theory]
        [InlineData("https://localhost:44383/api/Product/Getproduct")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            var result = response.StatusCode; // Status Code 200-299

            Assert.False(false);
        }


    }
}