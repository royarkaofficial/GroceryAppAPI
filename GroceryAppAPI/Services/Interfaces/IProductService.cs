using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductResponse> GetAll();
        public int Add(ProductRequest productRequest);
        public void Update(int id, string properties);
        public void Delete(int id);
    }
}
