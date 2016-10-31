namespace ChitChatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchIdToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChitChats", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChitChats", "Id");
            AddForeignKey("dbo.ChitChats", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChitChats", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChitChats", new[] { "Id" });
            DropColumn("dbo.ChitChats", "Id");
        }
    }
}
