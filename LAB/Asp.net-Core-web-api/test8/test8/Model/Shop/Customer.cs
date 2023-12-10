using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string _NumberPhone { get; set; } 

        public List<Order>? Orders { get; set; }


        //public string GetNumberPhone() => _NumberPhone;
        //public void SetNumberPhone(string numberphone)
        //{
        //    if (numberphone.Length == 10 && numberphone.StartsWith("06"))
        //    {
        //        try
        //        {
        //            int.Parse(numberphone);
        //           // var isNumeric = int.TryParse("123", out _);
        //        }
        //        catch (FormatException ex)
        //        {
        //            throw ex;
        //        }

        //        _NumberPhone = numberphone;
        //    }

        //}
    }


    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            //builder.Property(c=>c.Id).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            builder.Property(c => c.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(30).IsRequired();

            builder.HasIndex(c => c.FirstName).IsUnique();

            //builder.Property(c => c.Orders).IsRequired(false);
            builder.Property("_NumberPhone");

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(c => c.CustomerId);

            builder.HasData(
                    new 
                    {
                        Id = 1,
                        FirstName = "naie",
                        LastName = "nina",
                        _NumberPhone="06611112577",
                        //CreateDate=DateTime.Now,
                        //UpdateDate= (DateTime?)null
                    },
                    new {
                        Id=2,
                        FirstName="noa",
                        LastName="nella",
                        _NumberPhone = "06611112588",
                       // CreateDate = DateTime.Now,
                        //UpdateDate = (DateTime?)null
                    },
                     new
                     {
                         Id = 3,
                         FirstName = "joelle",
                         LastName = "tisa",
                         _NumberPhone = "06611112599",
                         //CreateDate = DateTime.Now,
                         //UpdateDate = (DateTime?)null
                     }
                  );



        }
    }
}

