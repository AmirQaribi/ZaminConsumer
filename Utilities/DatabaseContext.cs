using Microsoft.EntityFrameworkCore;
using System;
using Zamin.Infra.Data.Sql.Queries;
using ZaminConsumer.Models;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace ZaminConsumer.Utilities;



public class DatabaseContext(DbContextOptions<DatabaseContext> options) : BaseOutboxCommandDbContext(options) // Command Db
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<GroupMember> GroupMembers { get; set; } = null!;
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
//    public virtual DbSet<GroupMember.QueryModel> GroupMembers { get; set; } = null!;
//    public virtual DbSet<Group.QueryModel> Groups { get; set; } = null!;

//    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite(); }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<GroupMember.QueryModel>()
//            .HasOne(ug => ug.User)
//            .WithMany(u => u.GroupMembers)
//            .HasForeignKey(ug => ug.UserId)
//            .HasPrincipalKey(u => u.Id);

//        modelBuilder.Entity<GroupMember.QueryModel>()
//            .HasOne(ug => ug.Group)
//            .WithMany(g => g.GroupMembers)
//            .HasForeignKey(ug => ug.GroupId)
//            .HasPrincipalKey(g => g.Id);

//    }
//}
