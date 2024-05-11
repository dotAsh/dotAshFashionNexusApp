//Developed by Md. Ashik
using dotAshFashionNexus.Persistence.Data;
using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Persistence.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Linq.Expressions;

namespace dotAshFashionNexus.Persistence.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _memoryCache;
        public StockRepository(ApplicationDbContext db, IMemoryCache memoryCache) : base(db, memoryCache)
        {
            _db = db;
            _memoryCache = memoryCache;
        }

        public async Task UpdateAsync(int stockID, int variantId, int warehouseId , int quantity)
        {
           Stock? st =  await _db.Stocks.FirstOrDefaultAsync(s => s.StockID == stockID && s.VariantID == variantId && s.WarehouseID == warehouseId);
        
            if (st != null && st.Quantity >= quantity)
            {
                st.Quantity -= quantity;
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Insufficient stock.");
            }
        }

    }
}
