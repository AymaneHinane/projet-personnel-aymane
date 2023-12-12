


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x=>x.Id);

        builder.Property(x=>x.category).HasConversion(
            v => v.ToString(),
            v => (Category)Enum.Parse(typeof(Category), v));


        builder.HasData(
          new Product(){Id=new Guid("4436ef77-4ba3-4265-b265-968da0b04730"),Name="KCL",category=Category.rawMaterial},
          new Product(){Id=new Guid("8580a5c2-e5aa-430e-9b67-598d4e988c2d"),Name="DAP",category=Category.rawMaterial},
          new Product(){Id=new Guid("b7cf76e8-affa-45c6-a0f2-74add38778eb"),Name="TSP",category=Category.rawMaterial},
          new Product(){Id=new Guid("9f533133-2ad6-4b20-92f0-f66c105841fe"),Name="UREE",category=Category.rawMaterial},
          new Product(){Id=new Guid("a9d2fe5e-0d38-493c-a700-ed63485686e0"),Name="ACIDE HUMIQUE",category=Category.rawMaterial},
          new Product(){Id=new Guid("bab91ca4-100c-4a9c-ba75-b447c0b721c3"),Name="AMMONITRATE",category=Category.rawMaterial}
       );
    }

  
}