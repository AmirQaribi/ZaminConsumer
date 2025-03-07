using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Entities;
using Zamin.Infra.Data.Sql.Commands;
using ZaminConsumer.Utilities;

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
        public class Repository(CommandDbContext dbContext) : BaseCommandRepository<GroupMember, CommandDbContext, int>(dbContext), ICommandRepository<GroupMember, int> { }
        #endregion
    }
}
