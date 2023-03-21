using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared;

namespace EthBlockWebApi.Data
{
    public class EthBlockWebApiContext : DbContext
    {
        public EthBlockWebApiContext (DbContextOptions<EthBlockWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp1.Shared.Block> Block { get; set; } = default!;

        public DbSet<BlazorApp1.Shared.Transaction>? Transaction { get; set; }
    }
}
