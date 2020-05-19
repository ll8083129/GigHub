using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using GigHub.Core.Models;

namespace GigHub.Persistence.EntityConfigurations
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            // Keys configuration

            // Properties configurations
            Property(g => g.ArtistId)
                .IsRequired();

            Property(g => g.GenreId)
                .IsRequired();

            Property(g => g.Venue)
                .IsRequired()
                .HasMaxLength(255);

            // Relationships configuration
            HasMany(g => g.Attendances)
                .WithRequired(a => a.Gig)
                .WillCascadeOnDelete(false);
        }
    }
}