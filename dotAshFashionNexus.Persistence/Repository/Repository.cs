using dotAshFashionNexus.Persistence.Data;
using dotAshFashionNexus.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using dotAshFashionNexus.Persistence.Repository.IRepository;
//Developed by Md. Ashik
namespace dotAshFashionNexus.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
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

            
            return await query.FirstOrDefaultAsync(); 

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
