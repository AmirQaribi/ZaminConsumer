using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Entities;
using static ZaminConsumer.Commands.GroupCommands;
using Zamin.Infra.Data.Sql.Commands;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models
{
    public class UserGroup(int userId, int groupId) : AggregateRoot<int>
    {
        #region Properties
        public User? User { get; set; }
        public Group? Group { get; set; }
        public int UserId { get; set; } = userId;
        public int GroupId { get; set; } = groupId;
        #endregion
        #region Commands
        public static UserGroup Create(int userId, int groupId) => new(userId, groupId);
        #endregion
        #region Inner Classes
        public class CommandRepository(DatabaseContext dbContext) : BaseCommandRepository<UserGroup, DatabaseContext, int>(dbContext), ICommandRepository<UserGroup, int> { }
        #endregion
    }
}
