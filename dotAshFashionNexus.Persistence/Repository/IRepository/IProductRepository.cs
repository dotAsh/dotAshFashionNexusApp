using dotAshFashionNexus.Persistence.Models;
using System.Linq.Expressions;

namespace dotAshFashionNexus.Persistence.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
       

        Task<Product> UpdateAsync(Product entity);

        Task<IEnumerable<Object>> GetProd(ProductFilterCriteria filterCriteria);


    }
}
