using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration
{
	public class InvoiceCategoryConfiguration:IEntityTypeConfiguration<InvoiceCategory>
	{
		public InvoiceCategoryConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<InvoiceCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                  new InvoiceCategory() { Id = new Guid("0a8bb548-eafb-463c-a464-2c1f50533236") , Category = "Main d'oeuvre" },
                  new InvoiceCategory() { Id = new Guid("34d14645-8b66-440a-b4e9-c9e8191a8bc8") , Category = "Transport de distribution" },
                  new InvoiceCategory() { Id = new Guid("15bd2baf-b829-4a55-afd4-7cfdf7671dbc") , Category = "Transport de Matières premières" },
                  new InvoiceCategory() { Id = new Guid("3263e398-73e6-4460-9c75-0ed7b923612a") , Category = "Sacs" },
                  new InvoiceCategory() { Id = new Guid("a51f6b67-1a85-4c0f-aa24-01cd2bc684fa") , Category = "Manutention" },
                  new InvoiceCategory() { Id = new Guid("ac1c2389-a285-46cb-adb8-229ffc11029e") , Category = "Eléctricité" },
                  new InvoiceCategory() { Id = new Guid("e3128d6c-7e72-4dce-b6a6-4a1f1029e049") , Category = "Location Chariot" },
                  new InvoiceCategory() { Id = new Guid("4424f14b-6415-46df-86ce-036d86e3a451") , Category = "Location Chargeuse" },
                  new InvoiceCategory() { Id = new Guid("e7a8bca7-d4d8-46ff-be42-cc3d58bf0cf4") , Category = "Gasoil" },
                  new InvoiceCategory() { Id = new Guid("553ce4ae-4dd7-49d3-953a-ac1a9fa9bbd6") , Category = "Consommables" },
                  new InvoiceCategory() { Id = new Guid("f86fc5ec-e49f-4d14-a5c5-5f3c67bafe8b") , Category = "Analyse d'engrais" }
                );
        }
    }
}

