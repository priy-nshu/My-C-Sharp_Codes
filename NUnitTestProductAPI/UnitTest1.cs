using Newtonsoft.Json;
using NUnitTestProductAPI.Models;
using System.Reflection;
using System.Text;


namespace NUnitTestProductAPI
{
    [TestFixture]
    public class Tests
    {
        private const string ProductServiceName = "BrandService";
        private const string ProductControllerName = "BrandController";

        private HttpClient _httpClient;
        private Assembly _assembly;
        private Product _testProduct;

        [SetUp]
        public async Task Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:8080");
            _assembly = Assembly.GetAssembly(typeof(NUnitTestProductAPI.Services.BrandService));

            _testProduct = await CreateTestProduct();
        }
        private async Task<Product> CreateTestProduct()
        {
            var newProduct = new Product
            {
                BrandId = 997,
                ProductName = "Test Product",
                ListPrice = 9.99m,

            };
            var json =JsonConvert.SerializeObject(newProduct);
            var content =new StringContent(json,Encoding.UTF8,"appication/json");

            var response =await _httpClient.PostAsync("api/product",content);
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task Test_UpdateProduct_ValidProducr_UpdatesProduct()
        {
            var initialProduct = new Product
            {
                BrandId = 998,
                ProductName = "initial Product",
                ListPrice = 5.99m,
            };
            var json = JsonConvert.SerializeObject(initialProduct);
            var content = new StringContent(json, Encoding.UTF8, "appication/json");

            var createRespone= await _httpClient.PostAsync("api/product", content);
            createRespone.EnsureSuccessStatusCode();

            var createdProduct= JsonConvert.DeserializeObject<Product>(await createRespone.Content.ReadAsStringAsync());

            var updatedProduct = new Product
            {
                BrandId = createdProduct.BrandId,
                ProductName = "Updated Product",
                ListPrice = 19.99m,
            };

            var updatedJson =JsonConvert.SerializeObject(updatedProduct);
            var updatedContent = new StringContent(updatedJson, Encoding.UTF8, "application/json");

            var updatedResponse =await _httpClient.PutAsync($"api/product/{createdProduct.BrandId}", updatedContent);

            var getResponse = await _httpClient.GetAsync($"api/product/{createdProduct.BrandId}");
            getResponse.EnsureSuccessStatusCode();

            var getContent = await getResponse.Content.ReadAsStringAsync();
            var product =JsonConvert.DeserializeObject<Product>(getContent);

            Console.WriteLine(product.BrandId);
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.ListPrice);

            Assert.IsNotNull(product);
            Assert.AreEqual(updatedProduct.ProductName, product.ProductName);
            Assert.AreEqual(updatedProduct.ListPrice, product.ListPrice);

            
            Assert.Pass();
        }
    }
}