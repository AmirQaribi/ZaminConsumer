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

    #region Commands
    public static User Create(string username, int age) => new(username, age);
    public void Update(string username, int age)
    {
        Username = username;
        Age = age;

        //AddEvent(new
        //Updated(BusinessId.Value, Title.Value, Description.Value));
    }
    public void Delete()
    {
        if (_groupMembers.Count != 0)
            throw new InvalidEntityStateException("این کاربر عضو گروه است");

        //AddEvent(new BlogDeleted(BusinessId.Value));
}

    #endregion
    #region Inner Classes
    public class Repository(CommandDbContext dbContext) : BaseCommandRepository<User, CommandDbContext, int>(dbContext), ICommandRepository<User, int> { }
    #endregion
}
