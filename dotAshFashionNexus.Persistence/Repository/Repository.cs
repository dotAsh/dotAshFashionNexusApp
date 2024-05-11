using dotAshFashionNexus.Persistence.Data;
using dotAshFashionNexus.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using dotAshFashionNexus.Persistence.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
//Developed by Md. Ashik
namespace dotAshFashionNexus.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        private readonly IMemoryCache _memoryCache;
        public Repository(ApplicationDbContext db, IMemoryCache cache)
        {
            _db = db;
            _memoryCache = cache;
            dbset = _db.Set<T>();

        }


        public async Task CreateAsync(T entity)
        {

            await dbset.AddAsync(entity);
            await SaveAsync();

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 3, int pageNumber = 1)
        {

            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            }
           

            
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbset;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            var cacheKey = "GetAsync_" + (filter != null ? filter.ToString() : "NoFilter");
            if (_memoryCache.TryGetValue(cacheKey, out T cachedResult))
            {
                return cachedResult;
            }

            var result = await query.FirstOrDefaultAsync();
            if (result != null)
            {
                _memoryCache.Set(cacheKey, result, TimeSpan.FromMinutes(10));
            }

            return result;
        }

        public async Task RemoveAsync(T entity)
        {
            dbset.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

     
    }
}
