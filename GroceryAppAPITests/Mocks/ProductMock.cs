using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services;
using Moq;
using Newtonsoft.Json;

namespace GroceryAppAPITests.Mocks
{
    /// <summary>
    /// Mocks the repositories used by <see cref="ProductService"/>.
    /// </summary>
    public static class ProductMock
    {
        private static string BasePath = Environment.CurrentDirectory + "/TestData/";
        public static Mock<IProductRepository> ProductRepositoryMock = new Mock<IProductRepository>();

        /// <summary>
        /// Sets the mocks.
        /// </summary>
        public static void SetMocks()
        {
            MockProductRepository();
        }

        /// <summary>
        /// Mocks the implementation of <see cref="IProductRepository"/>.
        /// </summary>
        private static void MockProductRepository()
        {
            ProductRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) =>
            {
                var fileContent = File.ReadAllText(BasePath + "products.json");
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(fileContent);
                return products.FirstOrDefault(p => p.Id == id);
            });

            ProductRepositoryMock.Setup(repo => repo.GetAll()).Returns(() =>
            {
                var fileContent = File.ReadAllText(BasePath + "products.json");
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(fileContent);
                return products;
            });

            ProductRepositoryMock.Setup(repo => repo.Add(It.IsAny<Product>())).Returns(3);
            ProductRepositoryMock.Setup(repo => repo.UpdateStatusAsRemoved(It.IsAny<int>()));
            ProductRepositoryMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
    }
}
