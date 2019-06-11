namespace BFBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        participant_new_Id = c.Int(nullable: false),
                        participant_old_Id = c.Int(nullable: false),
                        currency_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.participant_new_Id)
                .ForeignKey("dbo.Participants", t => t.participant_old_Id)
                .ForeignKey("dbo.Currencies", t => t.currency_Id)
                .Index(t => t.participant_new_Id)
                .Index(t => t.participant_old_Id)
                .Index(t => t.currency_Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Transactions", "participant_old_Id", "dbo.Participants");
            DropForeignKey("dbo.Transactions", "participant_new_Id", "dbo.Participants");
            DropIndex("dbo.Transactions", new[] { "currency_Id" });
            DropIndex("dbo.Transactions", new[] { "participant_old_Id" });
            DropIndex("dbo.Transactions", new[] { "participant_new_Id" });
            DropTable("dbo.Participants");
            DropTable("dbo.Transactions");
            DropTable("dbo.Currencies");
        }
    }
}
