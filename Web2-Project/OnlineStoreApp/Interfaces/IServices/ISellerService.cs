using OnlineStoreApp.Models;

namespace OnlineStoreApp.Interfaces.IServices
{
    public interface ISellerService
    {
        public Task<List<Product>> GetProducts();
        public Task DeleteProduct(int id);
        public Task UpdateProduct(int id, Product product);
        public Task AddProduct(Product product);
        public Task<List<Order>> GetOrders();

        public Task<List<Order>> GetNewOrders();
    }
}
