using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Commands;

public static partial class GroupCommands
{
    public class GroupCreate : ICommand<Guid>, IWebRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Path => $"/{Routes.Group}";
    }
}
