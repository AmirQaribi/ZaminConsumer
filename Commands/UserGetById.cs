using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Commands;

public class UserGetById : IQuery<User.Query?>, IWebRequest
{
    public int Id { get; set; }

    public string Path => $"/{Routes.User}/single";
}
