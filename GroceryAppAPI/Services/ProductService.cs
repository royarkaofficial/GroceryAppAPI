using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;
using Newtonsoft.Json.Linq;

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
        public int Add(ProductRequest productRequest)
        {
            Validate(productRequest);
            var product = new Product()
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Stock = productRequest.Stock,
                ImageUrl = productRequest.ImageUrl,
                Status = (int)productRequest.Status
            };

            return _productRepository.Add(product);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        { 
            _productRepository.UpdateStatusAsRemoved(id);
        }

        /// <inheritdoc/>
        public IEnumerable<ProductResponse> GetAll()
        {
            var productResponses = new List<ProductResponse>();
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                productResponses.Add(new ProductResponse()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                    ImageUrl = product.ImageUrl,
                    Status= (ProductStatus)product.Status
                });
            }
            return productResponses.Where(p => p.Status is ProductStatus.Existing);
        }

        /// <inheritdoc/>
        public void Update(int id, string properties)
        {
            var existingProduct = _productRepository.Get(id);
            if (existingProduct is null) { throw new EntityNotFoundException(id, "Product"); }
            if (!string.IsNullOrWhiteSpace(properties))
            {
                var jsonProperties = JObject.Parse(properties);
                var setStatements = new List<string>();
                var product = new Product();
                foreach (var propertyInfo in jsonProperties.Properties())
                {
                    var name = propertyInfo.Name;
                    var value = propertyInfo.Value.ToString();
                    switch (name.ToUpperInvariant())
                    {
                        case "NAME":
                            if (string.IsNullOrWhiteSpace(value)) { throw new InvalidRequestDataException("Name is either not given or invalid."); }
                            setStatements.Add("[Name] = @Name");
                            product.Name = value;
                            break;
                        case "PRICE":
                            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out var price) && price > 0)
                            {
                                setStatements.Add("[Price] = @Price");
                                product.Price = price;
                            }
                            else { throw new InvalidRequestDataException("Price is either not given or invalid."); }
                            break;
                        case "STOCK":
                            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out var stock) && stock >= 0)
                            {
                                setStatements.Add("[Stock] = @Stock");
                                product.Stock = stock;
                            }
                            else { throw new InvalidRequestDataException("Stock is either not given or invalid."); }
                            break;
                        case "IMAGEURL":
                            if (string.IsNullOrEmpty(value)) { throw new InvalidRequestDataException("ImageUrl is either not given or invalid."); }
                            setStatements.Add("[ImageUrl] = @ImageUrl");
                            product.ImageUrl = value;
                            break;
                        case "STATUS":
                            if (!Enum.IsDefined(typeof(ProductStatus), value)) { throw new InvalidRequestDataException("ProductStatus is either not given or invalid."); }
                            setStatements.Add("[Status] = @Status");
                            product.Status = int.Parse(value);
                            break;
                        default:
                            throw new InvalidRequestDataException($"Product does not have any property like '{name}'");
                    }
                }
                var query = string.Join(", ", setStatements);
                product.Id = id;
                _productRepository.Update(query, product);
            }
        }

        /// <summary>
        /// Validates a product.
        /// </summary>
        /// <param name="productRequest">The product request.</param>
        /// <exception cref="ArgumentNullException">If product parameter is null.</exception>
        /// <exception cref="InvalidRequestDataException">If any invalid product property is given.</exception>
        private void Validate(ProductRequest productRequest) 
        {
            if (productRequest is null) { throw new ArgumentNullException("Product is either null or invalid."); }
            if (string.IsNullOrWhiteSpace(productRequest.Name)) { throw new InvalidRequestDataException("Name is either not given or invalid."); }
            if (productRequest.Price <= 0) { throw new InvalidRequestDataException("Price is either not given or invalid."); }
            if (productRequest.Stock <= 0) { throw new InvalidRequestDataException("Stock is either not given or invalid."); }
            if (string.IsNullOrEmpty(productRequest.ImageUrl)) { throw new InvalidRequestDataException("ImageUrl is either not given or invalid."); }
            if (!Enum.IsDefined(typeof(ProductStatus), productRequest.Status)) { throw new InvalidRequestDataException("ProductStatus is either not given or invalid."); }
        }
    }
}
