using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;
using ZaminConsumer.Models;

namespace ZaminConsumer.Utilities;

public class GroupCommands
{
    public class GetById : IQuery<Group.Query?>, IWebRequest
    {
        public int Id { get; set; }

        public string Path => $"/{Routes.Group}/single";
    }
    public class Create : ICommand<Guid>, IWebRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Path => $"/{Routes.Group}";
    }
    public class Update : ICommand, IWebRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Path => $"/{Routes.Group}";
    }
    public class Delete : ICommand, IWebRequest
    {
        public int Id { get; set; }
        public string Path => $"/{Routes.Group}";
    }
}
