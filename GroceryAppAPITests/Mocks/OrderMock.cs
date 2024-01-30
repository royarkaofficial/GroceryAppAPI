﻿using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services;
using Moq;
using Newtonsoft.Json;

namespace GroceryAppAPITests.Mocks
{
    /// <summary>
    /// Mocks the repositories used by <see cref="OrderService"/>.
    /// </summary>
    public static class OrderMock
    {
        private static string BasePath = Environment.CurrentDirectory + "/TestData/";
        public static Mock<IOrderRepository> OrderRepositoryMock = new Mock<IOrderRepository>();
        public static Mock<IUserRepository> UserRepositoryMock = new Mock<IUserRepository>();
        public static Mock<IPaymentRepository> PaymentRepositoryMock = new Mock<IPaymentRepository>();
        public static Mock<IProductRepository> ProductRepositoryMock = new Mock<IProductRepository>();
        public static Mock<IOrderProductRepository> OrderProductRepositoryMock = new Mock<IOrderProductRepository>();

        /// <summary>
        /// Sets the mocks.
        /// </summary>
        public static void SetMocks()
        {
            MockOrderRepository();
            MockUserRepository();
            MockPaymentRepository();
            MockProductRepository();
            MockOrderProductRepository();
        }

        /// <summary>
        /// Mocks the implementation of <see cref="IOrderRepository"/>.
        /// </summary>
        private static void MockOrderRepository()
        {
            OrderRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<int>())).Returns((int userId) =>
            {
                var fileContent = File.ReadAllText(BasePath + "orders.json");
                var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(fileContent);
                return orders.Where(order => order.UserId == userId);
            });

            OrderRepositoryMock.Setup(repo => repo.Add(It.IsAny<Order>())).Returns(3);
            OrderRepositoryMock.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<int>()));
            OrderRepositoryMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }

        /// <summary>
        /// Mocks the implementation of <see cref="IUserRepository"/>.
        /// </summary>
        private static void MockUserRepository()
        {
            UserRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) =>
            {
                var fileContent = File.ReadAllText(BasePath + "users.json");
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(fileContent);
                return users.FirstOrDefault(user => user.Id == id);
            });
        }

        /// <summary>
        /// Mocks the implementation of <see cref="IPaymentRepository"/>.
        /// </summary>
        private static void MockPaymentRepository()
        {
            PaymentRepositoryMock.Setup(repo => repo.Add(It.IsAny<Payment>())).Returns(3);
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
        }

        /// <summary>
        /// Mocks the implementation of <see cref="IOrderProductRepository"/>.
        /// </summary>
        private static void MockOrderProductRepository()
        {
            OrderProductRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<int>())).Returns((int orderId) =>
            {
                var fileContent = File.ReadAllText(BasePath + "orders_products.json");
                var orderProducts = JsonConvert.DeserializeObject<IEnumerable<OrderProduct>>(fileContent);
                return orderProducts.Where(op => op.OrderId == orderId);
            });

            OrderProductRepositoryMock.Setup(repo => repo.Add(It.IsAny<OrderProduct>()));
            OrderProductRepositoryMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
    }
}
