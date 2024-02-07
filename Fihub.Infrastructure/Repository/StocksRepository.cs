using Finhub.Core.Domain.Entitites;
using Finhub.Core.Domain.RepositoryContracts;
using Finhub.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Infrastructure.Repository
{
    public class StocksRepository : IStocksRepository
    {
        private StockMarketDbContext _dbContext {  get; set; }

        public StocksRepository(StockMarketDbContext dbContext)
        { //this should be scoped 
            _dbContext = dbContext;
        }

        public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            await _dbContext.BuyOrders.AddAsync(buyOrder);
            await _dbContext.SaveChangesAsync();
            //updates the ID before returning it
            return buyOrder;
        }

        public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        { //same as CreateBuyOrder but with SellOrder instead
            await _dbContext.SellOrders.AddAsync(sellOrder);
            await _dbContext.SaveChangesAsync();
            //updates the ID before returning it
            return sellOrder;
        }

        public async Task<List<BuyOrder>> GetBuyOrders()
        {
            List<BuyOrder> list = await _dbContext.BuyOrders.ToListAsync();
            return list;
        }

        public async Task<List<SellOrder>> GetSellOrders()
        {
            List<SellOrder> list = await _dbContext.SellOrders.ToListAsync();
            return list;
        }
    }
}
