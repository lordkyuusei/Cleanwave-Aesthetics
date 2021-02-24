using Cleanwave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleanwave.Application.Common.Interfaces
{
    public interface ICleanwaveDbContext
    {
        public DbSet<CHILLWAVE_SONG> ChillwaveSongs { get; set; }
    }
}
