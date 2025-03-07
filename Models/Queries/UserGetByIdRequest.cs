using Swashbuckle.AspNetCore.Annotations;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models.Queries;

public class UserGetByIdRequest : IQuery<UserQueryResponse?>, IWebRequest
{
    public int Id { get; set; }

    [SwaggerIgnore]
    public string Path => $"/{Routes.User}/getById";
}