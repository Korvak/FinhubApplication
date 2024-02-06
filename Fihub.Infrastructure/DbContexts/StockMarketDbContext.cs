using Finhub.Core.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fihub.Infrastructure.DbContexts
{
    public class StockMarketDbContext : DbContext
    {
        DbSet<BuyOrder> BuyOrders { get; set; }

        DbSet<SellOrder> SellOrders { get; set; }


    }
}
