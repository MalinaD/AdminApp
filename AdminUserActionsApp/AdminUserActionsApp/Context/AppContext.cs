
namespace AdminUserActionsApp.Context
{
    using AdminUserActionsApp.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Configuration;
    using System.Data.Entity;
    using Migrations;

    public class AppContext : IdentityDbContext<User>, IAppContext
    {

        public AppContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, AdminUserActionsApp.Migrations.Configuration>());
        }

        public static AppContext Create()
        {
            return new AppContext();
        }

        public IDbSet<Group> Groups { get; set; }

        public IDbSet<UserLanguage> Languages { get; set; }

        public IDbSet<AdministrationLog> AdministrationLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //if we need on delete action
            //modelBuilder.Entity<Endorcement>().HasRequired(x => x.UserSkill).WithMany(x => x.Endorcements).WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}