using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Commands;

public static partial class GroupCommands
{
    public class GroupGetById : IQuery<Group.Query?>, IWebRequest
    {
        public int Id { get; set; }

        public string Path => $"/{Routes.Group}/single";
    }
}
