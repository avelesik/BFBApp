namespace BFBApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BFBApp.Models.ModelExchange>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BFBApp.Models.ModelExchange context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Currencies.AddOrUpdate(t => t.Name, ExchangeData.GetCurrencies().ToArray());
            context.SaveChanges();
            context.Participants.AddOrUpdate(t => t.Name, ExchangeData.GetParticipiants().ToArray());
            context.SaveChanges();
            context.Transactions.AddOrUpdate(t => new { t.Amount, t.Price, t.DateTime }, ExchangeData.GetTransacions(context).ToArray());
            context.SaveChanges();
        }
    }
}
