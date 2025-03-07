using Microsoft.EntityFrameworkCore;
using System;
using ZaminConsumer.Models;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace ZaminConsumer.Utilities;



public class CommandDbContext(DbContextOptions<CommandDbContext> options) : BaseOutboxCommandDbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<GroupMember> GroupMembers { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
