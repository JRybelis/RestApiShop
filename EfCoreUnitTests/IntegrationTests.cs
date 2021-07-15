using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RestApiShop;
using RestApiShop.Entities.ShopItems;
using Xunit;

namespace EfCoreUnitTests
{
    public class IntegrationTests
    {
        private readonly CustomWebApplicationFactory<Startup> _factory = new CustomWebApplicationFactory<Startup>();

        [Fact]
        public async Task IntegrationTest()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("/Vegetable");
            
            var stringContent = await result.Content.ReadAsStringAsync();
            var vegetables = JsonConvert.DeserializeObject<List<Vegetable>>(stringContent);

            result.EnsureSuccessStatusCode();
            vegetables.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Delete_IntegrationTest()
        {
            var client = _factory.CreateClient();
            await client.DeleteAsync("/Vegetable/1");
            
            var result = await client.GetAsync("/Vegetable");
            var stringContent = await result.Content.ReadAsStringAsync();

            var vegetables = JsonConvert.DeserializeObject<List<Vegetable>>(stringContent);    
            
            result.EnsureSuccessStatusCode();
            vegetables.Should().BeEmpty();
        }
        
    }
}
