using Cleanwave.Application.Common.Interfaces;
using Cleanwave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleanwave.Infrastructure.Persistence
{
    public partial class CleanwaveDbContext : DbContext, ICleanwaveDbContext
    {
        public CleanwaveDbContext()
        {}

        public CleanwaveDbContext(DbContextOptions opt) : base(opt)
        {}

        public virtual DbSet<CHILLWAVE_SONG> ChillwaveSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
