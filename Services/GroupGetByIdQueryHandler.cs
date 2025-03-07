using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;
using static ZaminConsumer.Commands.GroupCommands;
using static ZaminConsumer.Models.Group;

namespace ZaminConsumer.Services;

//public class GroupGetByIdQueryHandler(ZaminServices zaminServices, IGroupQueryRepository repository) : QueryHandler<GroupGetById, Query?>(zaminServices)
//{
//    public override async Task<QueryResult<Query?>> Handle(GroupGetById query)
//    {
//        var group = await repository.ExecuteAsync(query);
//        return Result(group);
//    }
//}