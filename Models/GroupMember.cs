using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Entities;
using static ZaminConsumer.Commands.GroupCommands;
using Zamin.Infra.Data.Sql.Commands;
using ZaminConsumer.Utilities;
using ZaminConsumer.Commands;

namespace ZaminConsumer.Models
{
    public class GroupMember(int userId, int groupId) : AggregateRoot<int>
    {
        #region Properties
        public User? User { get; set; }
        public Group? Group { get; set; }
        public int UserId { get; set; } = userId;
        public int GroupId { get; set; } = groupId;
        #endregion
        #region Commands
        public static GroupMember Create(int userId, int groupId) => new(userId, groupId);
        #endregion
        #region Inner Classes
        public class Query
        {
            public int Id { get; set; }
            public string UserId { get; set; } = string.Empty;
            public string GroupId { get; set; } = string.Empty;
        }
        //public interface IGroupMemberQueryRepository { public Task<Query?> ExecuteAsync(FindGroupMemberId query); }
        public class CommandRepository(DatabaseContext dbContext) : BaseCommandRepository<GroupMember, DatabaseContext, int>(dbContext), ICommandRepository<GroupMember, int> { }
        #endregion
    }
}
