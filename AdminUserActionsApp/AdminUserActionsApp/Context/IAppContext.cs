namespace AdminUserActionsApp.Context
{
    using AdminUserActionsApp.Models;
    using System.Data.Entity;

    public interface IAppContext
    {
        IDbSet<Group> Groups { get; set; }

        IDbSet<UserLanguage> Languages { get; set; }

        IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        int SaveChanges();
    }
}
