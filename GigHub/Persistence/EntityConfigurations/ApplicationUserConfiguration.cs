using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using GigHub.Core.Models;

namespace GigHub.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            HasMany(n => n.UserNotifications)
                .WithRequired(n => n.User)
                .WillCascadeOnDelete(false);
        }
    }
}