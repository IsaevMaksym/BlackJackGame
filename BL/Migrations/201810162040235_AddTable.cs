namespace BL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PLAYERS", "Games_GameID", c => c.Int());
            CreateIndex("dbo.PLAYERS", "Games_GameID");
            AddForeignKey("dbo.PLAYERS", "Games_GameID", "dbo.Games", "GameID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PLAYERS", "Games_GameID", "dbo.Games");
            DropIndex("dbo.PLAYERS", new[] { "Games_GameID" });
            DropColumn("dbo.PLAYERS", "Games_GameID");
        }
    }
}
