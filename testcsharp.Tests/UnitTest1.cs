using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace testcsharp.Tests
{
    public class MiddlewareTests : IClassFixture<WebApplicationFactory<testcsharp.Startup>>
    {
        private readonly WebApplicationFactory<testcsharp.Startup> _factory;

        public MiddlewareTests(WebApplicationFactory<testcsharp.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EndpointReturnsHelloWorld()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/"); // Assuming your endpoint is the root.
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World, from ASP.NET!", responseString);
        }
    }
}