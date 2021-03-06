﻿namespace AdminUserActionsApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class User : IdentityUser
    {

        private ICollection<UserLanguage> userLanguages;
        private ICollection<Group> groups;

        public User()
        {
            this.ContactInfo = new ContactInfo();
            this.groups = new HashSet<Group>();
            this.Messages = new HashSet<Message>();
        }

        public virtual ICollection<Message> Messages { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public DateTime? DateRegister { get; set; }


        [InverseProperty("Members")]
        public virtual ICollection<Group> Groups
        {
            get { return this.groups; }
            set { this.groups = value; }
        }

        public class Message
        {
            public int Id { get; set; }
            public string MessageText { get; set; }
            public DateTime DateCreated { get; set; }
        }

    }
}