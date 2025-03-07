using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Commands;

public static partial class UserCommands
{
    public class UserCreate : ICommand<Guid>, IWebRequest
    {
        public string Username { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Path => $"/{Routes.User}";
    }
}
