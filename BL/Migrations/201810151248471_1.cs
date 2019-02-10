namespace BL
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                {
                    CardID = c.Int(nullable: false, identity: true),
                    CardName = c.String(maxLength: 20, fixedLength: true, unicode: false),
                    CardSuit = c.String(maxLength: 20, fixedLength: true, unicode: false),
                    CardValue = c.Int(nullable: false),
                    Image = c.Binary(),
                })
                .PrimaryKey(t => t.CardID);

            CreateTable(
                "dbo.Games",
                c => new
                {
                    GameID = c.Int(nullable: false, identity: true),
                    Player_1_ID = c.Int(),
                    GameLog = c.String(nullable: false, maxLength: 100, unicode: false),
                    WINNER = c.Int(),
                    Date = c.DateTime(),
                })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.PLAYERS", t => t.Player_1_ID)
                .Index(t => t.Player_1_ID);

            CreateTable(
                "dbo.PLAYERS",
                c => new
                {
                    PlayerID = c.Int(nullable: false, identity: true),
                    NickName = c.String(nullable: false, maxLength: 20),
                    Password = c.String(nullable: false, maxLength: 50),

                    GamesCount = c.Int(),
                    WinCount = c.Int(),
                    Coins = c.Int(),
                })
                .PrimaryKey(t => t.PlayerID);

            CreateTable(
                "dbo.sysdiagrams",
                c => new
                {
                    diagram_id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 128),
                    principal_id = c.Int(nullable: false),
                    version = c.Int(),
                    definition = c.Binary(),
                })
                .PrimaryKey(t => t.diagram_id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Games", "Player_1_ID", "dbo.PLAYERS");
            DropIndex("dbo.Games", new[] { "Player_1_ID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.PLAYERS");
            DropTable("dbo.Games");
            DropTable("dbo.Cards");
        }
    }
}
