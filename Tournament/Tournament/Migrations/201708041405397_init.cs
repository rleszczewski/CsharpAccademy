namespace Tournament.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchUpEntryModel",
                c => new
                    {
                        MatchUpEntryModelId = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        ParentMatchup_MatchUpModelId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchUpEntryModelId)
                .ForeignKey("dbo.MatchUpModel", t => t.ParentMatchup_MatchUpModelId)
                .ForeignKey("dbo.TeamModel", t => t.MatchUpEntryModelId)
                .Index(t => t.MatchUpEntryModelId)
                .Index(t => t.ParentMatchup_MatchUpModelId);
            
            CreateTable(
                "dbo.MatchUpModel",
                c => new
                    {
                        MatchUpModelId = c.Int(nullable: false),
                        MatchupRound = c.Int(nullable: false),
                        Tournament_TournamentModelId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchUpModelId)
                .ForeignKey("dbo.TournamentModel", t => t.Tournament_TournamentModelId)
                .ForeignKey("dbo.TeamModel", t => t.MatchUpModelId)
                .Index(t => t.MatchUpModelId)
                .Index(t => t.Tournament_TournamentModelId);
            
            CreateTable(
                "dbo.TournamentModel",
                c => new
                    {
                        TournamentModelId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        EntryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TournamentModelId);
            
            CreateTable(
                "dbo.TeamModel",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.PersonModel",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        NickName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        TeamRefId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.TeamModel", t => t.TeamRefId)
                .Index(t => t.TeamRefId);
            
            CreateTable(
                "dbo.PrizeModel",
                c => new
                    {
                        PrizeModelId = c.Int(nullable: false, identity: true),
                        PlaceNumber = c.Int(nullable: false),
                        PlaceName = c.String(),
                        PrizeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrizePercentage = c.Double(nullable: false),
                        TournamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrizeModelId)
                .ForeignKey("dbo.TournamentModel", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.TeamModelTournamentModel",
                c => new
                    {
                        TeamModel_TeamId = c.Int(nullable: false),
                        TournamentModel_TournamentModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamModel_TeamId, t.TournamentModel_TournamentModelId })
                .ForeignKey("dbo.TeamModel", t => t.TeamModel_TeamId, cascadeDelete: true)
                .ForeignKey("dbo.TournamentModel", t => t.TournamentModel_TournamentModelId, cascadeDelete: true)
                .Index(t => t.TeamModel_TeamId)
                .Index(t => t.TournamentModel_TournamentModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchUpEntryModel", "MatchUpEntryModelId", "dbo.TeamModel");
            DropForeignKey("dbo.MatchUpModel", "MatchUpModelId", "dbo.TeamModel");
            DropForeignKey("dbo.MatchUpModel", "Tournament_TournamentModelId", "dbo.TournamentModel");
            DropForeignKey("dbo.PrizeModel", "TournamentId", "dbo.TournamentModel");
            DropForeignKey("dbo.TeamModelTournamentModel", "TournamentModel_TournamentModelId", "dbo.TournamentModel");
            DropForeignKey("dbo.TeamModelTournamentModel", "TeamModel_TeamId", "dbo.TeamModel");
            DropForeignKey("dbo.PersonModel", "TeamRefId", "dbo.TeamModel");
            DropForeignKey("dbo.MatchUpEntryModel", "ParentMatchup_MatchUpModelId", "dbo.MatchUpModel");
            DropIndex("dbo.TeamModelTournamentModel", new[] { "TournamentModel_TournamentModelId" });
            DropIndex("dbo.TeamModelTournamentModel", new[] { "TeamModel_TeamId" });
            DropIndex("dbo.PrizeModel", new[] { "TournamentId" });
            DropIndex("dbo.PersonModel", new[] { "TeamRefId" });
            DropIndex("dbo.MatchUpModel", new[] { "Tournament_TournamentModelId" });
            DropIndex("dbo.MatchUpModel", new[] { "MatchUpModelId" });
            DropIndex("dbo.MatchUpEntryModel", new[] { "ParentMatchup_MatchUpModelId" });
            DropIndex("dbo.MatchUpEntryModel", new[] { "MatchUpEntryModelId" });
            DropTable("dbo.TeamModelTournamentModel");
            DropTable("dbo.PrizeModel");
            DropTable("dbo.PersonModel");
            DropTable("dbo.TeamModel");
            DropTable("dbo.TournamentModel");
            DropTable("dbo.MatchUpModel");
            DropTable("dbo.MatchUpEntryModel");
        }
    }
}
