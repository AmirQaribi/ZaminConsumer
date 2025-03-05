using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace ZaminConsumer.Models;

public class User : AggregateRoot<int>
{

    #region Properties
    public string Username { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public IReadOnlyList<UserGroup> UserGroups => [.. _userGroups];
    private readonly List<UserGroup> _userGroups = [];
    #endregion

    public User(string username, NationalCode nationalCode)
    {
        Username = username;
        NationalCode = nationalCode;

        //AddEvent(new BlogCreated(BusinessId.Value, Title.Value, Description.Value));
    }


    public static User Create(string username, NationalCode nationalCode) => new(username, nationalCode);

    public void Update(string username, NationalCode nationalCode)
    {
        Username = username;
        NationalCode = nationalCode;

        //AddEvent(new BlogUpdated(BusinessId.Value, Title.Value, Description.Value));
    }
    public void Delete()
    {
        if (_userGroups.Count != 0)
            throw new InvalidEntityStateException("این کاربر عضو گروه است");

        //AddEvent(new BlogDeleted(BusinessId.Value));
    }
    public void JoinGroup(int groupId)
    {
        if (_userGroups.Any(ug => ug.GroupId.Equals(groupId)))
            throw new InvalidEntityStateException("این کاربر قبلا عضو این گروه شده است");

        var userGroup = UserGroup.Create(Id, groupId);
        _userGroups.Add(userGroup);

        //AddEvent(new BlogPostCreated(post.BusinessId.Value, BusinessId.Value, post.Title.Value));
    }

    public void LeaveGroup(int groupId)
    {
        var group = _userGroups.FirstOrDefault(ug => ug.GroupId == groupId) ?? throw new InvalidEntityStateException("این یوزر عضو این گروه نیست");
        _userGroups.Remove(group);

        //AddEvent(new BlogPostDeleted(group.BusinessId.Value, BusinessId.Value));
    }

    public class Query
    {
        public int Id { get; set; }
        public string NationalCode { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
