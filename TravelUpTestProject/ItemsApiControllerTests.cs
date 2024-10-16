using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelUp.Models;

namespace TravelUpTestProject
{
    public class ItemsApiControllerTests
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Structure", "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method", Justification = "<Pending>")]
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            // Assuming you have a test server setup
            _client = new HttpClient();
        }

        [Test]
        public async Task Test_GetAllItems_ReturnsItems()
        {
            // Act
            var response = await _client.GetAsync("/api/items");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<Item>>(content);
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count > 0); // Assuming there are items in the DB
        }

        [Test]
        public async Task Test_AddItem_ReturnsCreatedItem()
        {
            // Arrange
            var newItem = new Item { Name = "TestItem", Description = "TestDescription" };
            var json = JsonConvert.SerializeObject(newItem);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/items", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var createdItem = JsonConvert.DeserializeObject<Item>(await response.Content.ReadAsStringAsync());
            Assert.AreEqual("TestItem", createdItem.Name);
        }

        // Similarly, you can write tests for PUT, DELETE, and other endpoints.
    }
}
