namespace AdminUserActionsApp.Context
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class AppData
    {
        private IAppContext context;
        private IDictionary<Type, object> repositories;

        public AppData(IAppContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }


        public IRepository<Group> Groups
        {
            get { return this.GetRepository<Group>(); }
        }
       

        public IRepository<AdministrationLog> AdministrationLogs
        {
            get { return this.GetRepository<AdministrationLog>(); }
        } 

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);


                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    
    }
}