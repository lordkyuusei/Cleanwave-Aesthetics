using Cleanwave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cleanwave.Infrastructure.Persistence.Configuration
{
    internal class CHILLWAVE_SONG_Configuration : IEntityTypeConfiguration<CHILLWAVE_SONG>
    {
        public void Configure(EntityTypeBuilder<CHILLWAVE_SONG> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.TITLE)
                .IsRequired();
        }
    }
}
