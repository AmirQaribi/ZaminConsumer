using Swashbuckle.AspNetCore.Annotations;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models.Queries;

public class GroupMemberGetByIdRequest : IQuery<GroupMemberQueryResponse?>, IWebRequest
{
    public int Id { get; set; }

    [SwaggerIgnore]
    public string Path => $"/{Routes.GroupMember}";
}