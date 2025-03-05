using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;
using ZaminConsumer.Models;

namespace ZaminConsumer.Utilities;

public class UserCommands
{
    public class GetById : IQuery<User.Query?>, IWebRequest
    {
        public int Id { get; set; }

        public string Path => $"/{Routes.User}/single";
    }
    public class Create : ICommand<Guid>, IWebRequest
    {
        public string Username { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public string Path => $"/{Routes.User}";
    }
    public class Update : ICommand, IWebRequest
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public string Path => $"/{Routes.User}";
    }
    public class Delete : ICommand, IWebRequest
    {
        public int Id { get; set; }
        public string Path => $"/{Routes.User}";
    }
    public class JoinGroup : ICommand<Guid>, IWebRequest
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Path => $"/{Routes.User}/join";
    }
    public class LeaveGroup : ICommand, IWebRequest
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Path => $"/{Routes.User}/leave";
    }
}
