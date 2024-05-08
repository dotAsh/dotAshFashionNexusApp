//Developed by Md. Ashik
using dotAshFashionNexus.Persistence.Data;
using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Persistence.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace dotAshFashionNexus.Persistence.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        
        public ProductRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
            
        }
       

 
        public async Task<Product> UpdateAsync(Product entity)
        {
           // entity.UpdatedDate = DateTimeOffset.UtcNow;
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
