using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Volvox.Helios.Domain.ModuleSettings;

namespace Volvox.Helios.Service.Extensions
{
    public static class LookingForGroupExtensions
    {
        public static void BuildLookingForGroupEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookingForGroupSettings>()
                .ToTable("LookingForGroupSettings", "lfg");

            modelBuilder.Entity<LookingForGroupSession>()
                .ToTable("LookingForGroupSessions", "lfg");

            modelBuilder.Entity<LookingForGroupRoleRestriction>()
                .ToTable("LookingForGroupRoleRestriction", "lfg");

            modelBuilder.Entity<LookingForGroupPlayerRole>()
                .ToTable("LookingForGroupPlayerRole", "lfg");

            modelBuilder.Entity<LookingForGroupPlayerRoleMap>()
                .ToTable("LookingForGroupPlayerRoleMap", "lfg");

            modelBuilder.Entity<LookingForGroupSession>()
                .HasKey(x => x.Id)
                .ForSqlServerIsClustered();

            modelBuilder.Entity<LookingForGroupSession>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LookingForGroupRoleRestriction>()
                .HasKey(x => x.Id)
                .ForSqlServerIsClustered();

            modelBuilder.Entity<LookingForGroupRoleRestriction>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LookingForGroupPlayerRole>()
                .HasKey(x => x.Id)
                .ForSqlServerIsClustered();

            modelBuilder.Entity<LookingForGroupPlayerRole>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LookingForGroupPlayerRoleMap>()
                .HasKey(k => new { k.PlayerRoleId, k.SessionId })
                .ForSqlServerIsClustered();

            modelBuilder.Entity<LookingForGroupSettings>()
                .HasMany(x => x.Sessions)
                .WithOne()
                .HasForeignKey(x => x.GuildId);

            modelBuilder.Entity<LookingForGroupSession>()
                .HasMany<LookingForGroupRoleRestriction>()
                .WithOne()
                .HasForeignKey(x => x.SessionId);

            modelBuilder.Entity<LookingForGroupPlayerRoleMap>()
                .HasOne<LookingForGroupSession>()
                .WithMany()
                .HasForeignKey(x => x.SessionId);

            modelBuilder.Entity<LookingForGroupPlayerRoleMap>()
                .HasOne<LookingForGroupPlayerRole>()
                .WithMany()
                .HasForeignKey(x => x.PlayerRoleId);

            modelBuilder.Entity<LookingForGroupSession>()
                .HasData(new LookingForGroupSession
                {
                    Id = Guid.NewGuid(),
                    GuildId = 486220073933996043,
                    Description = "Test LFG for things and whatnot",
                    HasMaximumCapacity = true,
                    MaximumMembers = 24,
                    ShortIdentifyer = "TLG",
                    Title = "Test LFG"
                });
        }
    }
}
