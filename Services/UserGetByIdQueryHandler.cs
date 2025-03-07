using FluentValidation;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;
using ZaminConsumer.Models.Queries;
using static ZaminConsumer.Models.UserQuery;

namespace ZaminConsumer.Services;
public class UserGetByIdQueryHandler(ZaminServices zaminServices, IRepository  repository) : QueryHandler<UserGetByIdRequest, UserQueryResponse?>(zaminServices)
{
    public override async Task<QueryResult<UserQueryResponse?>> Handle(UserGetByIdRequest query)
    {
        var user = await repository.ExecuteAsync(query);
        return Result(user);
    }
}

//public class UserGetByIdQueryValidator : AbstractValidator<UserGetByIdRequest>
//{
//    public UserGetByIdQueryValidator(ITranslator translator)
//    {
//        RuleFor(query => query.Id)
//            .NotEmpty()
//            .WithMessage(translator["Required", nameof(UserGetByIdRequest.Id)]);
//    }
//}