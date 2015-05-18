namespace AdminUserActionsApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Group
    {
        private ICollection<User> members;


        public Group()
        {
            this.members = new HashSet<User>();

        }

        public int Id { get; set; }

        public string Title { get; set; }

        public GroupType Type { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public string Website { get; set; }

        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

    }
}