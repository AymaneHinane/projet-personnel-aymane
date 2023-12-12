using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration.SecurityConfiguration
{
	public class RoleConfiguration:IEntityTypeConfiguration<IdentityRole>
	{
	
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
              new IdentityRole
              {
                  Id = "7f3950fa-9093-492b-9a9a-0f4b41138c34",
                  Name = "ADMIN",
                  NormalizedName = "ADMIN"
              },
              new IdentityRole
              {
                  Id = "466381e5-3ef0-45fd-b2f3-52a027e5d4d8",
                  Name = "SURAC",
                  NormalizedName = "SURAC"
              },
              new IdentityRole
              {
                  Id = "271b1113-e4a8-4031-b99f-f203932cf51a",
                  Name = "SUTA",
                  NormalizedName = "SUTA"
              },
              new IdentityRole
              {
                  Id = "f753d221-c96e-486b-ac40-403dd11ea541",
                  Name = "COSUMAR ZAIO",
                  NormalizedName = "COSUMAR ZAIO"
              },
              new IdentityRole
              {
                  Id = "999f3d6b-9626-401f-a863-b86d79f7cb3a",
                  Name = "SUNABEL",
                  NormalizedName = "SUNABEL"
              },
              new IdentityRole
              {
                  Id = "8a8e723c-d8d1-46b5-a2e4-c17705b5dee3",
                  Name = "COSUMAR SIDI BENNOUR",
                  NormalizedName = "COSUMAR SIDI BENNOUR"
              }
             );








        }
    }
}

