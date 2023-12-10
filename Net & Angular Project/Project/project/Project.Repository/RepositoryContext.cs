
using System.Reflection.Emit;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Entities.Event;
using Project.Entities.Models;
using Project.Repository.Configuration;
using Project.Repository.Configuration.SecurityConfiguration;


namespace  Project.Repository;




public class RepositoryContext : IdentityDbContext<User>
{

    private readonly IMediator _mediator;

    public RepositoryContext(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator;

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
        modelBuilder.ApplyConfiguration(new StockConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());
        modelBuilder.ApplyConfiguration(new RecipientConfiguration());
        modelBuilder.ApplyConfiguration(new TransferOperationConfiguration());
        modelBuilder.ApplyConfiguration(new RecipientTransferConfiguration());
        modelBuilder.ApplyConfiguration(new TransferHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    }


    public DbSet<Warehouse>? Warehouses { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Stock>? Stocks { get; set; }
    public DbSet<Transfer>? Transfers { get; set; }
    public DbSet<TransferOperation>? TransferOperation { get; set; }
    public DbSet<Recipients>? Recipients { get; set; }
    public DbSet<RecipientTransfer>? RecipientTransfers { get; set; }
    public DbSet<TransferHistory>? TransferHistories { get; set; }
    public DbSet<StockChangeHistory> StockChangeHistories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceCategory> InvoiceCategories { get; set; }


    public async Task<int> SaveChangesStockAsync(CancellationToken cancellationToken = default)
    {
        await PublishDomainEventsAsync();
        await StockHistoriesInsert();

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEntities = ChangeTracker
          .Entries<Entity>()
          .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
         .SelectMany(x => x.Entity.DomainEvents!)
         .ToList();

        domainEntities.ToList()
         .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
    }

    private async Task StockHistoriesInsert()
    {
        var modifiedEntries = ChangeTracker.Entries<Stock>()
            .Where(e => e.State == EntityState.Modified)
            .ToList();

        foreach (var entry in modifiedEntries)
        {
            foreach (var property in entry.OriginalValues.Properties)
            {
                var originalValue = entry.OriginalValues[property];
                var currentValue = entry.CurrentValues[property];

                if (!object.Equals(originalValue, currentValue))
                {
                    var product = await this.Products!.FindAsync(entry.Entity.productId);
                    var warehouse = await this.Warehouses!.FindAsync(entry.Entity.warehouseId);

                    var historyEntry = new StockChangeHistory
                    {
                        PropertyNameEng = property.Name,
                        PropertyNameFr = getPropertyStockName(property.Name, product!.category),
                        OldValue = (decimal)originalValue!,
                        NewValue = (decimal)currentValue!,
                        ProductName = product!.Name,
                        ProductCategory = product!.category,
                        warehouseId = warehouse!.Id,
                        UpdatedDate = DateTime.UtcNow
                    };

                    StockChangeHistories.Add(historyEntry);
                }
            }
        }
    }

    private string getPropertyStockName(string propertyName,Category category)
    {
        if (category.Equals(Category.rawMaterial))
        {
            int currentYear = DateTime.Now.Year;

            switch (propertyName)
            {
                case "OrderStock":
                    return $"commandée {(currentYear - 1).ToString()}-{currentYear.ToString()}";
                case "DeliverStock":return "receptionné A date";
                case "ConsumeStock":return "consommée";
                case "RemainingStock":return $"restant {(currentYear - 1).ToString()}-{currentYear.ToString()}";
                case "LastYearRemainingStock":
                    return $"restant {(currentYear - 1).ToString()}-{currentYear.ToString()}";
                case "DAPStock":return "MP disponible";
                case "TransferedStockExitTotal":return "stocks sortants";
                case "TransferedStockEntryTotal":return "stocks entrants";
                default: return propertyName;
            }
        }
        else if (category.Equals(Category.finishedProduct))
        {
            switch(propertyName)
            {
                case "StockProduced":return "produit ACJ";
                case "TransferedStockExitTotal":return "livrée CDA ACJ";
                case "RemainingStock":return "stock Sucrerie";
                default: return propertyName;
            }
        }

        return "";
    }


}


