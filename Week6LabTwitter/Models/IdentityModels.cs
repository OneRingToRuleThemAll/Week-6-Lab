﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.ObjectModel;

namespace Week6LabTwitter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class TwitterUser : IdentityUser
    {
        public Collection<Post> Posts { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TwitterUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class TwitterDbContext : IdentityDbContext<TwitterUser>
    {
        public TwitterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }
        public DbSet<Post> Posts { get; set; }


    }
}