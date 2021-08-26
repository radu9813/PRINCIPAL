using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HelloWorldWebApp.Models;

namespace HelloWorldWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWorldWebApp.Models.Skill> Skill { get; set; }

        public DbSet<HelloWorldWebApp.Models.TeamMember> TeamMembers { get; set; }

        public DbSet<HelloWorldWebApp.Models.User> User { get; set; }
    }
}
