namespace ChitChatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedchitchat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChitChats",
                c => new
                    {
                        ChitChatID = c.Int(nullable: false, identity: true),
                        ChitChatText = c.String(),
                    })
                .PrimaryKey(t => t.ChitChatID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChitChats");
        }
    }
}
