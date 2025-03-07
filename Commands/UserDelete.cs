using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Commands;

public static partial class UserCommands
{
    public class UserDelete : ICommand, IWebRequest
    {
        public int Id { get; set; }
        public string Path => $"/{Routes.User}";
    }
}
