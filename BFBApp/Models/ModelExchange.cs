namespace BFBApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelExchange : DbContext
    {
        public ModelExchange()
            : base("name=ModelExchange")
        {
        }

        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currencies>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Currencies)
                .HasForeignKey(e => e.currency_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Participants>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Participants)
                .HasForeignKey(e => e.participant_new_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Participants>()
                .HasMany(e => e.Transactions1)
                .WithRequired(e => e.Participants1)
                .HasForeignKey(e => e.participant_old_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
