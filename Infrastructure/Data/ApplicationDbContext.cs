using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientResponse> ClientResponses { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendResponse> FriendResponses { get; set; }
        public DbSet<Adjective> Adjectives { get; set; }
    }
}
