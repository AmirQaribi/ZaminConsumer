using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;
using ZaminConsumer.Models;

namespace ZaminConsumer.Utilities;

public class QueryDbContext(DbContextOptions<QueryDbContext> options) : BaseQueryDbContext(options)
{
    public virtual DbSet<UserQuery> Users { get; set; } = null!;
    public virtual DbSet<GroupMemberQuery> GroupMembers { get; set; } = null!;
    public virtual DbSet<GroupQuery> Groups { get; set; } = null!;

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite(); }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<GroupMember.QueryModel>()
        //    .HasOne(ug => ug.User)
        //    .WithMany(u => u.GroupMembers)
        //    .HasForeignKey(ug => ug.UserId)
        //    .HasPrincipalKey(u => u.Id);

        //modelBuilder.Entity<GroupMember.QueryModel>()
        //    .HasOne(ug => ug.Group)
        //    .WithMany(g => g.GroupMembers)
        //    .HasForeignKey(ug => ug.GroupId)
        //    .HasPrincipalKey(g => g.Id);
    }
}
