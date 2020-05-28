namespace YcTeam.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddPointProject = c.String(unicode: false),
                        AddPointContent = c.String(unicode: false),
                        AddPointMethod = c.String(unicode: false),
                        SelfPoint = c.Int(nullable: false),
                        SelfReason = c.String(unicode: false),
                        AuditPoint = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyEvaluations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        StandardCategoryId = c.Guid(nullable: false),
                        EvContentId = c.Guid(nullable: false),
                        SelfPoint = c.Int(nullable: false),
                        Reason = c.String(unicode: false),
                        AuditPoint = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvContents", t => t.EvContentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.StandardCategories", t => t.StandardCategoryId)
                .Index(t => t.ProjectId)
                .Index(t => t.StandardCategoryId)
                .Index(t => t.EvContentId);
            
            CreateTable(
                "dbo.EvContents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContentCode = c.Int(nullable: false),
                        Content = c.String(unicode: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StandardCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        CategoryCode = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DemocraticEvaluations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DemocraticSums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlowInstances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NodeNumber = c.Guid(nullable: false),
                        NodeName = c.String(maxLength: 50, storeType: "nvarchar"),
                        StatusName = c.String(unicode: false),
                        StartUserId = c.Guid(),
                        StartUser = c.String(unicode: false),
                        OperatingUserId = c.Guid(),
                        OperatingUser = c.String(unicode: false),
                        ToDoUserId = c.Guid(),
                        ToDoUser = c.String(unicode: false),
                        OperatedUserId = c.Guid(nullable: false),
                        OperatedUser = c.String(unicode: false),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                        RequisitionId = c.Guid(),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlowNodes", t => t.NodeNumber)
                .Index(t => t.NodeNumber);
            
            CreateTable(
                "dbo.FlowNodes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NodeNumber = c.Guid(nullable: false),
                        NodeName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        OperateUserId = c.Guid(),
                        OperateUser = c.String(unicode: false),
                        NextNodeNumber = c.String(unicode: false),
                        LastNodeNumber = c.String(unicode: false),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlowRecords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WorkId = c.Guid(),
                        CurrentNodeNumber = c.Guid(nullable: false),
                        CurrentNode = c.String(maxLength: 50, storeType: "nvarchar"),
                        OperateUserId = c.Guid(),
                        OperateUser = c.String(maxLength: 50, storeType: "nvarchar"),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                        IsRead = c.Boolean(nullable: false),
                        IsPass = c.Boolean(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlowInstances", t => t.WorkId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.PointShows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PointSums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysDeparts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DepartName = c.String(unicode: false),
                        RegionCity = c.String(unicode: false),
                        RegionCounty = c.String(unicode: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysNavs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NavName = c.String(unicode: false),
                        NavUrl = c.String(unicode: false),
                        NavIcons = c.String(unicode: false),
                        NavOrd = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysNavItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NodeName = c.String(unicode: false),
                        Pid = c.Int(nullable: false),
                        RootId = c.Int(nullable: false),
                        Deep = c.Int(nullable: false),
                        NodeUrl = c.String(unicode: false),
                        NodeOrd = c.Int(nullable: false),
                        NodeIcons = c.String(unicode: false),
                        NavId = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysNavs", t => t.NavId)
                .Index(t => t.NavId);
            
            CreateTable(
                "dbo.SysNavRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        NavItemId = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysNavItems", t => t.NavItemId)
                .ForeignKey("dbo.SysRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.NavItemId);
            
            CreateTable(
                "dbo.SysRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleName = c.String(unicode: false),
                        SortOrder = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysRolePermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                        IsAllowed = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysPermissions", t => t.PermissionId)
                .ForeignKey("dbo.SysRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.SysPermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ControllerName = c.String(unicode: false),
                        ControllerAttribute = c.String(unicode: false),
                        ActionName = c.String(unicode: false),
                        ActionAttribute = c.String(unicode: false),
                        IsController = c.Int(nullable: false),
                        IsAllowedNoneRole = c.Int(nullable: false),
                        IsAllowedAllRole = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SysUserId = c.Guid(nullable: false),
                        SysRoleId = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysRoles", t => t.SysRoleId)
                .ForeignKey("dbo.SysUsers", t => t.SysUserId)
                .Index(t => t.SysUserId)
                .Index(t => t.SysRoleId);
            
            CreateTable(
                "dbo.SysUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        RealName = c.String(unicode: false),
                        SysDepartId = c.Guid(nullable: false),
                        CurrentStaffState = c.Int(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDeparts", t => t.SysDepartId)
                .Index(t => t.SysDepartId);
            
            CreateTable(
                "dbo.SysStaffStateHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VetoEvaluations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Project = c.String(unicode: false),
                        VetoConditon = c.String(unicode: false),
                        VetoContent = c.String(unicode: false),
                        StaffState = c.Int(nullable: false),
                        StaffStateName = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysStaffStateHistories", "UserId", "dbo.SysUsers");
            DropForeignKey("dbo.SysNavRoles", "RoleId", "dbo.SysRoles");
            DropForeignKey("dbo.SysUserRoles", "SysUserId", "dbo.SysUsers");
            DropForeignKey("dbo.SysUsers", "SysDepartId", "dbo.SysDeparts");
            DropForeignKey("dbo.SysUserRoles", "SysRoleId", "dbo.SysRoles");
            DropForeignKey("dbo.SysRolePermissions", "RoleId", "dbo.SysRoles");
            DropForeignKey("dbo.SysRolePermissions", "PermissionId", "dbo.SysPermissions");
            DropForeignKey("dbo.SysNavRoles", "NavItemId", "dbo.SysNavItems");
            DropForeignKey("dbo.SysNavItems", "NavId", "dbo.SysNavs");
            DropForeignKey("dbo.FlowRecords", "WorkId", "dbo.FlowInstances");
            DropForeignKey("dbo.FlowInstances", "NodeNumber", "dbo.FlowNodes");
            DropForeignKey("dbo.DailyEvaluations", "StandardCategoryId", "dbo.StandardCategories");
            DropForeignKey("dbo.DailyEvaluations", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.DailyEvaluations", "EvContentId", "dbo.EvContents");
            DropIndex("dbo.SysStaffStateHistories", new[] { "UserId" });
            DropIndex("dbo.SysUsers", new[] { "SysDepartId" });
            DropIndex("dbo.SysUserRoles", new[] { "SysRoleId" });
            DropIndex("dbo.SysUserRoles", new[] { "SysUserId" });
            DropIndex("dbo.SysRolePermissions", new[] { "PermissionId" });
            DropIndex("dbo.SysRolePermissions", new[] { "RoleId" });
            DropIndex("dbo.SysNavRoles", new[] { "NavItemId" });
            DropIndex("dbo.SysNavRoles", new[] { "RoleId" });
            DropIndex("dbo.SysNavItems", new[] { "NavId" });
            DropIndex("dbo.FlowRecords", new[] { "WorkId" });
            DropIndex("dbo.FlowInstances", new[] { "NodeNumber" });
            DropIndex("dbo.DailyEvaluations", new[] { "EvContentId" });
            DropIndex("dbo.DailyEvaluations", new[] { "StandardCategoryId" });
            DropIndex("dbo.DailyEvaluations", new[] { "ProjectId" });
            DropTable("dbo.VetoEvaluations");
            DropTable("dbo.SysStaffStateHistories");
            DropTable("dbo.SysUsers");
            DropTable("dbo.SysUserRoles");
            DropTable("dbo.SysPermissions");
            DropTable("dbo.SysRolePermissions");
            DropTable("dbo.SysRoles");
            DropTable("dbo.SysNavRoles");
            DropTable("dbo.SysNavItems");
            DropTable("dbo.SysNavs");
            DropTable("dbo.SysDeparts");
            DropTable("dbo.PointSums");
            DropTable("dbo.PointShows");
            DropTable("dbo.FlowRecords");
            DropTable("dbo.FlowNodes");
            DropTable("dbo.FlowInstances");
            DropTable("dbo.DemocraticSums");
            DropTable("dbo.DemocraticEvaluations");
            DropTable("dbo.StandardCategories");
            DropTable("dbo.Projects");
            DropTable("dbo.EvContents");
            DropTable("dbo.DailyEvaluations");
            DropTable("dbo.Contributes");
        }
    }
}
