﻿using System.Data.Entity.ModelConfiguration;
using Svbase.Core.Data.Entities;

namespace Svbase.Core.Data.Configuration
{
    public class StreetConfiguration : EntityTypeConfiguration<Street>
    {
        public StreetConfiguration()
        {
            ToTable("Street");
            HasKey(x => x.Id);

            HasRequired(x => x.City)
                .WithMany(x => x.Streets)
                .HasForeignKey(x => x.CityId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.Districts)
                .WithMany(x => x.Streets)
                .Map(t => t.MapLeftKey("StreetId")
                    .MapRightKey("DistrictId")
                    .ToTable("StreetDistrict"));
        }
    }
}
