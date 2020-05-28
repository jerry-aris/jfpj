namespace YcTeam.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DemocraticEvaluations", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.DemocraticEvaluations", "DailyEvaluationId", c => c.Guid(nullable: false));
            AddColumn("dbo.DemocraticEvaluations", "ContributeId", c => c.Guid(nullable: false));
            AddColumn("dbo.DemocraticEvaluations", "VetoEvaluationId", c => c.Guid(nullable: false));
            AddColumn("dbo.DemocraticEvaluations", "ComprehensivePoint", c => c.Int(nullable: false));
            AddColumn("dbo.PointSums", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.DemocraticEvaluations", "UserId");
            CreateIndex("dbo.DemocraticEvaluations", "DailyEvaluationId");
            CreateIndex("dbo.DemocraticEvaluations", "ContributeId");
            CreateIndex("dbo.DemocraticEvaluations", "VetoEvaluationId");
            CreateIndex("dbo.PointSums", "UserId");
            AddForeignKey("dbo.DemocraticEvaluations", "ContributeId", "dbo.Contributes", "Id");
            AddForeignKey("dbo.DemocraticEvaluations", "DailyEvaluationId", "dbo.DailyEvaluations", "Id");
            AddForeignKey("dbo.DemocraticEvaluations", "UserId", "dbo.SysUsers", "Id");
            AddForeignKey("dbo.DemocraticEvaluations", "VetoEvaluationId", "dbo.VetoEvaluations", "Id");
            AddForeignKey("dbo.PointSums", "UserId", "dbo.SysUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointSums", "UserId", "dbo.SysUsers");
            DropForeignKey("dbo.DemocraticEvaluations", "VetoEvaluationId", "dbo.VetoEvaluations");
            DropForeignKey("dbo.DemocraticEvaluations", "UserId", "dbo.SysUsers");
            DropForeignKey("dbo.DemocraticEvaluations", "DailyEvaluationId", "dbo.DailyEvaluations");
            DropForeignKey("dbo.DemocraticEvaluations", "ContributeId", "dbo.Contributes");
            DropIndex("dbo.PointSums", new[] { "UserId" });
            DropIndex("dbo.DemocraticEvaluations", new[] { "VetoEvaluationId" });
            DropIndex("dbo.DemocraticEvaluations", new[] { "ContributeId" });
            DropIndex("dbo.DemocraticEvaluations", new[] { "DailyEvaluationId" });
            DropIndex("dbo.DemocraticEvaluations", new[] { "UserId" });
            DropColumn("dbo.PointSums", "UserId");
            DropColumn("dbo.DemocraticEvaluations", "ComprehensivePoint");
            DropColumn("dbo.DemocraticEvaluations", "VetoEvaluationId");
            DropColumn("dbo.DemocraticEvaluations", "ContributeId");
            DropColumn("dbo.DemocraticEvaluations", "DailyEvaluationId");
            DropColumn("dbo.DemocraticEvaluations", "UserId");
        }
    }
}
