using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Infra.Data.Sql.Commands;
using ZaminConsumer.Utilities;
using static ZaminConsumer.Commands.GroupCommands;

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
    public class Query
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
    public interface IGroupQueryRepository { public Task<Query?> ExecuteAsync(GroupGetById query); }
    public class CommandRepository(DatabaseContext dbContext) : BaseCommandRepository<Group, DatabaseContext, int>(dbContext), ICommandRepository<Group, int> { }
    #endregion
}
