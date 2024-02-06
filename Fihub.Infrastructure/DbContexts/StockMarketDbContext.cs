using Finhub.Core.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Finhub.Infrastructure.DbContexts
{
    public class StockMarketDbContext : DbContext
    {

        public StockMarketDbContext(DbContextOptions<StockMarketDbContext> options) : base(options)
        {
            //we need the DbContextOptions or the Extension method will throw error.
        }

        DbSet<BuyOrder> BuyOrders { get; set; }

        DbSet<SellOrder> SellOrders { get; set; }


    }
}
