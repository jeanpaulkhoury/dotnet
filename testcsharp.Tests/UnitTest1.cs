using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ConsoleApplication
{
    public class MiddlewareTests : IClassFixture<WebApplicationFactory<ConsoleApplication.Startup>>
    {
        private readonly WebApplicationFactory<ConsoleApplication.Startup> _factory;

        public MiddlewareTests(WebApplicationFactory<ConsoleApplication.Startup> factory)
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