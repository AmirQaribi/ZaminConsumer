using FluentValidation;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;
using ZaminConsumer.Models.Queries;
using static ZaminConsumer.Models.GroupMemberQuery;

namespace ZaminConsumer.Services;
public class GroupMemberGetByIdQueryHandler(ZaminServices zaminServices, IRepository repository) : QueryHandler<GroupMemberGetByIdRequest, GroupMemberQueryResponse?>(zaminServices)
{
    public override async Task<QueryResult<GroupMemberQueryResponse?>> Handle(GroupMemberGetByIdRequest query)
    => Result(await repository.ExecuteAsync(query));
}