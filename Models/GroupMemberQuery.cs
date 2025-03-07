using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models;

public class GroupMemberQuery
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }
    public List<GroupMemberQuery>? GroupMembers { get; set; }

    public interface IRepository
    {
        //public Task<GroupMemberQueryResponse?> ExecuteAsync(UserJoinGroup query);
        //public Task<GroupMemberQueryResponse?> ExecuteAsync(UserLeaveGroup query);
        public Task<GroupMemberQueryResponse?> ExecuteAsync(GroupMemberGetByIdRequest query);
    }
    public class Repository(QueryDbContext dbContext) : BaseQueryRepository<QueryDbContext>(dbContext), IRepository
    {
        public Task<GroupMemberQueryResponse?> ExecuteAsync(GroupMemberGetByIdRequest query)
            => _dbContext.GroupMembers.Select(c => new GroupMemberQueryResponse()
            {
                Id = c.Id,
                UserId = c.UserId,
                GroupId = c.GroupId
            }).FirstOrDefaultAsync(c => c.Id.Equals(query.Id));
        //public async Task<GroupMemberQueryResponse?> ExecuteAsync(GroupMemberCreate query) => await ExecuteAsync(query.GroupId, query.UserId);
        //public async Task<GroupMemberQueryResponse?> ExecuteAsync(GroupMemberDelete query) => await ExecuteAsync(query.GroupId, query.UserId);
        //private Task<GroupMemberQueryResponse?> ExecuteAsync(int groupId, int userId)
        //    => _dbContext.GroupMembers.Select(c => new GroupMemberQueryResponse()
        //    {
        //        Id = c.Id,
        //        UserId = c.UserId,
        //        GroupId = c.GroupId
        //    }).FirstOrDefaultAsync(c => c.GroupId.Equals(groupId) && c.UserId.Equals(userId));
    }
}
