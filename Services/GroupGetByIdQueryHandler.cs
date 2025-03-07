using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;
using ZaminConsumer.Models.Queries;
using static ZaminConsumer.Models.GroupQuery;

namespace ZaminConsumer.Services;

public class GroupGetByIdQueryHandler(ZaminServices zaminServices, IRepository repository) : QueryHandler<GroupGetByIdRequest, GroupQueryResponse?>(zaminServices)
{
    public override async Task<QueryResult<GroupQueryResponse?>> Handle(GroupGetByIdRequest query)
    {
        var group = await repository.ExecuteAsync(query);
        return Result(group);
    }
}