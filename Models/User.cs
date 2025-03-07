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
    public void JoinGroup(int groupId)
    {
        if (_groupMembers.Any(ug => ug.GroupId.Equals(groupId)))
            throw new InvalidEntityStateException("این کاربر قبلا عضو این گروه شده است");

        var groupMembers = GroupMember.Create(Id, groupId);
        _groupMembers.Add(groupMembers);

        //AddEvent(new BlogPostCreated(post.BusinessId.Value, BusinessId.Value, post.Title.Value));
    }

    public void LeaveGroup(int groupId)
    {
        var group = _groupMembers.FirstOrDefault(ug => ug.GroupId == groupId) ?? throw new InvalidEntityStateException("این یوزر عضو این گروه نیست");
        _groupMembers.Remove(group);

        //AddEvent(new BlogPostDeleted(group.BusinessId.Value, BusinessId.Value));
    }


    #endregion
    #region Inner Classes
    public class Repository(CommandDbContext dbContext) : BaseCommandRepository<User, CommandDbContext, int>(dbContext), ICommandRepository<User, int> { }
    #endregion
}
