using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;
using ZaminConsumer.Commands;
using static ZaminConsumer.Models.User;

namespace ZaminConsumer.Services;

//public class UserGetByIdQueryHandler(ZaminServices zaminServices, IUserQueryRepository repository) : QueryHandler<UserGetById, Query?>(zaminServices)
//{
//    public override async Task<QueryResult<Query?>> Handle(UserGetById query)
//    {
//        var user = await repository.ExecuteAsync(query);
//        return Result(user);
//    }
//}
