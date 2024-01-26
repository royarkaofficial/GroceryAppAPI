using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements product related functionalities.
    /// </summary>
    /// <seealso cref="IProductService"/>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <inheritdoc/>
        public int Add(Product product)
        {
            Validate(product);

            return _productRepository.Add(product);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        /// <inheritdoc/>
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        /// <inheritdoc/>
        public void Update(int id, Product product)
        {
            Validate(product);
            _productRepository.Update(id, product);
        }

        /// <summary>
        /// Validates a product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="ArgumentNullException">If product parameter is null.</exception>
        /// <exception cref="InvalidRequestDataException">If any invalid product property is given.</exception>
        private void Validate(Product product) 
        {
            if (product is null)
            {
                throw new ArgumentNullException("Product is either null or invalid.");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new InvalidRequestDataException("Name is either not given or invalid.");
            }

            if (product.Price <= 0)
            {
                throw new InvalidRequestDataException("Price is either not given or invalid.");
            }

            if (product.Stock < 0)
            {
                throw new InvalidRequestDataException("Stock is either not given or invalid.");
            }
        }
    }
}
