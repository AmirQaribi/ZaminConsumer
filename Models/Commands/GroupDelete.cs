using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models.Commands;

public class GroupDelete : ICommand, IWebRequest
{
    public int Id { get; set; }
    public string Path => $"/{Routes.Group}";
}
