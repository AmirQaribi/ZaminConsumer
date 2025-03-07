using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models;

public partial class UserQuery
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public int Age { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }
    public List<GroupMemberQuery>? GroupMembers { get; set; }
    public interface IRepository { public Task<UserQueryResponse?> ExecuteAsync(UserGetByIdRequest query); }
    public class Repository(QueryDbContext dbContext) : BaseQueryRepository<QueryDbContext>(dbContext), IRepository
    {
        public async Task<UserQueryResponse?> ExecuteAsync(UserGetByIdRequest query)
            => await _dbContext.Users.Select(c => new UserQueryResponse()
            {
                Id = c.Id,
                UserName = c.UserName,
                Age = c.Age
            }).FirstOrDefaultAsync(c => c.Id.Equals(query.Id));
    }
}