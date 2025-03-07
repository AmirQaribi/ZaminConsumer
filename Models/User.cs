using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Infra.Data.Sql.Commands;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models;


public partial class User(string username, int age) : AggregateRoot<int>
{

    #region Properties
    public string Username { get; private set; } = username;
    public int Age { get; private set; } = age;
    public IReadOnlyList<GroupMember> GroupMembers => [.. _groupMembers];
    private readonly List<GroupMember> _groupMembers = [];
    #endregion

    public static User Create(string username, int age) => new(username, age);
    public void Update(string username, int age)
    {
        Username = username;
        Age = age;
    }
    public void Delete()
    {
        if (_groupMembers.Count != 0)
            throw new InvalidEntityStateException("این کاربر عضو گروه است");
    }
    public class Repository(CommandDbContext dbContext) : BaseCommandRepository<User, CommandDbContext, int>(dbContext), ICommandRepository<User, int> { }
}
