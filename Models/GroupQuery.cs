using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models;

public class GroupQuery
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }

    public interface IRepository { public Task<GroupQueryResponse?> ExecuteAsync(GroupGetByIdRequest query); }
    public class Repository(QueryDbContext dbContext) : BaseQueryRepository<QueryDbContext>(dbContext), IRepository
    {
        public async Task<GroupQueryResponse?> ExecuteAsync(GroupGetByIdRequest query)
            => await _dbContext.Groups.Select(c => new GroupQueryResponse()
            {
                Id = c.Id,
                Title = c.Title
            }).FirstOrDefaultAsync(c => c.Id.Equals(query.Id));
    }
}