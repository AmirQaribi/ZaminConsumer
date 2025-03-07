using Microsoft.EntityFrameworkCore;
using System;
using Zamin.Infra.Data.Sql.Queries;
using ZaminConsumer.Models;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace ZaminConsumer.Utilities;



public class DatabaseContext(DbContextOptions<DatabaseContext> options) : BaseOutboxCommandDbContext(options) // Command Db
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserGroup> UserGroups { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
//public class DatabaseContext : BaseQueryDbContext
//{
//    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

//    public virtual DbSet<User.QueryModel> Users { get; set; } = null!;
//    public virtual DbSet<UserGroup.QueryModel> UserGroups { get; set; } = null!;
//    public virtual DbSet<Group.QueryModel> Groups { get; set; } = null!;

//    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite(); }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<UserGroup.QueryModel>()
//            .HasOne(ug => ug.User)
//            .WithMany(u => u.UserGroups)
//            .HasForeignKey(ug => ug.UserId)
//            .HasPrincipalKey(u => u.Id);

//        modelBuilder.Entity<UserGroup.QueryModel>()
//            .HasOne(ug => ug.Group)
//            .WithMany(g => g.UserGroups)
//            .HasForeignKey(ug => ug.GroupId)
//            .HasPrincipalKey(g => g.Id);

//    }
//}
