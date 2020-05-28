using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YcTeam.Models.Master;
using YcTeam.Models.Sys;
using YcTeam.Models.WorkFlow;
using YcTeam.Models.Planing;

namespace YcTeam.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class YcContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“YcModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“YcTeam.Models.YcModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“YcModel”
        //连接字符串。
        public YcContext() : base(nameOrConnectionString: "con")
        {
            //策略一：数据库不存在时重新创建数据库
            //Database.SetInitializer<YcContext>(new CreateDatabaseIfNotExists<YcContext>());

            //策略二：每次启动应用程序时创建数据库
            //Database.SetInitializer<YcContext>(new DropCreateDatabaseAlways<YcContext>());

            //策略三：模型更改时重新创建数据库
            Database.SetInitializer<YcContext>(new DropCreateDatabaseIfModelChanges<YcContext>());

            //策略四：从不创建数据库
            //Database.SetInitializer<YcContext>(strategy: null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Code First模式级联删除是默认打开的,关闭外键关系下的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        #region 系统管理
        //导航滑块
        public DbSet<SysNav> SysNav { get; set; }

        //导航节点
        public DbSet<SysNavItem> SysNavItem { get; set; }

        //用户
        public DbSet<SysUser> SysUser { get; set; }

        //导航角色中间表
        public DbSet<SysNavRole> SysNavRole { get; set; }

        //用户角色
        public DbSet<SysRole> SysRole { get; set; }

        //用户角色中间表
        public DbSet<SysUserRole> SysUserRole { get; set; }

        //部门
        public DbSet<SysDepart> SysDepart { get; set; }
        //在职状态历史记录
        public DbSet<SysStaffStateHistory> SysStaffStateHistory { get; set; }
        #endregion

        #region 主数据
      
        //权限角色中间表
        public DbSet<SysRolePermission> SysRolePermission { get; set; }

        //权限信息
        public DbSet<SysPermission> SysPermission { get; set; }
        #endregion

        #region 工作流
        //工作流实例
        public DbSet<FlowInstance> FlowInstance { get; set; }

        //工作流记录
        public DbSet<FlowRecord> FlowRecord { get; set; }

        //工作流节点
        public DbSet<FlowNode> FlowNode { get; set; }
        #endregion

        #region 评价管理
        //评价标准分类
        public DbSet<StandardCategory> StandardCategory { get; set;}
        //评价标准
        public DbSet<EvContent> EvContent { get; set; }
        //评价项目
        public DbSet<Project> Project { get; set; }
        #endregion

        #region 评价流程
        //日常管理评价
        public DbSet<DailyEvaluation> DailyEvaluation { get; set; }
        //贡献积分评价
        public DbSet<Contribute> Contribute { get; set; }
        //否决扣分评价
        public DbSet<VetoEvaluation> VetoEvaluation { get; set; }
        //积分晾晒表
        public DbSet<PointShow> PointShow { get; set; }
        //民主测评
        public DbSet<DemocraticEvaluation> DemocraticEvaluation { get; set; }
        //民主测评汇总
        public DbSet<DemocraticSum> DemocraticSum { get; set; }
        //积分汇总
        public DbSet<PointSum> PointSum { get; set; }
        #endregion#
    }
}