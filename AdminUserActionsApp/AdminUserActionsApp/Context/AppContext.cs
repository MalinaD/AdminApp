namespace AdminUserActionsApp.Context
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity;
    using Migrations;
    using System.Configuration;

    public class AppContext : IdentityDbContext<User>, IAppContext
    {

        public AppContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Configuration>());
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