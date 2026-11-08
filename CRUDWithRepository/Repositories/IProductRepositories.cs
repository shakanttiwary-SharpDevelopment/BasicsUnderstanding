using CRUDWithRepository.Models;

namespace CRUDWithRepository.Repositories
{
    public interface IProductRepositories
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(Guid id);
        public Task AddAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(Guid id);   
    }
}
