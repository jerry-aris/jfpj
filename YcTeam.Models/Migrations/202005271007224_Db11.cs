namespace YcTeam.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointShows", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.PointShows", "DailyEvaluationId", c => c.Guid(nullable: false));
            AddColumn("dbo.PointShows", "ContributeId", c => c.Guid(nullable: false));
            AddColumn("dbo.PointShows", "VetoEvaluationId", c => c.Guid(nullable: false));
            AddColumn("dbo.PointShows", "Sum", c => c.Int(nullable: false));
            AddColumn("dbo.VetoEvaluations", "VetoCondition", c => c.String(unicode: false));
            CreateIndex("dbo.PointShows", "UserId");
            CreateIndex("dbo.PointShows", "DailyEvaluationId");
            CreateIndex("dbo.PointShows", "ContributeId");
            CreateIndex("dbo.PointShows", "VetoEvaluationId");
            AddForeignKey("dbo.PointShows", "ContributeId", "dbo.Contributes", "Id");
            AddForeignKey("dbo.PointShows", "DailyEvaluationId", "dbo.DailyEvaluations", "Id");
            AddForeignKey("dbo.PointShows", "UserId", "dbo.SysUsers", "Id");
            AddForeignKey("dbo.PointShows", "VetoEvaluationId", "dbo.VetoEvaluations", "Id");
            DropColumn("dbo.VetoEvaluations", "VetoConditon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VetoEvaluations", "VetoConditon", c => c.String(unicode: false));
            DropForeignKey("dbo.PointShows", "VetoEvaluationId", "dbo.VetoEvaluations");
            DropForeignKey("dbo.PointShows", "UserId", "dbo.SysUsers");
            DropForeignKey("dbo.PointShows", "DailyEvaluationId", "dbo.DailyEvaluations");
            DropForeignKey("dbo.PointShows", "ContributeId", "dbo.Contributes");
            DropIndex("dbo.PointShows", new[] { "VetoEvaluationId" });
            DropIndex("dbo.PointShows", new[] { "ContributeId" });
            DropIndex("dbo.PointShows", new[] { "DailyEvaluationId" });
            DropIndex("dbo.PointShows", new[] { "UserId" });
            DropColumn("dbo.VetoEvaluations", "VetoCondition");
            DropColumn("dbo.PointShows", "Sum");
            DropColumn("dbo.PointShows", "VetoEvaluationId");
            DropColumn("dbo.PointShows", "ContributeId");
            DropColumn("dbo.PointShows", "DailyEvaluationId");
            DropColumn("dbo.PointShows", "UserId");
        }
    }
}
