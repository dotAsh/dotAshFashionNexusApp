using dotAshFashionNexus.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotAshFashionNexus.Persistence.Repository.IRepository
{
    public interface IStockRepository: IRepository<Stock>
    {
        public Task UpdateAsync(int stockID, int variantId, int warehouseId, int quantity);
    }
}
