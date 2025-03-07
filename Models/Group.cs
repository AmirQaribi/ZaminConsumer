using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Infra.Data.Sql.Commands;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models;

public class Group(string title) : AggregateRoot<int>
{
    #region Properties
    public string Title { get; private set; } = title;
    public IReadOnlyList<GroupMember> GroupMembers => [.. _groupMembers];
    private readonly List<GroupMember> _groupMembers = [];
    #endregion
    #region Commands
    public static Group Create(string title) => new(title);
    public void Update(string title)
    {
        Title = title;
        //AddEvent(new BlogUpdated(BusinessId.Value, Zamin.Core.Domain.Toolkits.ValueObjects.Title.Value, Description.Value));
    }
    public void Delete()
    {
        if (_groupMembers.Count != 0)
            throw new InvalidEntityStateException("این گروه دارای یک یا چند کاربر است");
        //AddEvent(new BlogDeleted(BusinessId.Value));
    }
    #endregion
    #region Inner Classes
    public class Repository(CommandDbContext dbContext) : BaseCommandRepository<Group, CommandDbContext, int>(dbContext), ICommandRepository<Group, int> { }
    #endregion
}
