using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Commands;
using ZaminConsumer.Models;
using static ZaminConsumer.Commands.GroupCommands;

namespace ZaminConsumer.Services;

public class GroupCreateCommandHandler(ZaminServices zaminServices, ICommandRepository<Group, int> repository) : CommandHandler<GroupCreate, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(GroupCreate command)
    {
        var group = Group.Create(command.Title);
        await repository.InsertAsync(group);
        await repository.CommitAsync();
        Console.WriteLine("Yo3 {0}", group.BusinessId.Value.ToString());
        return Ok(group.BusinessId.Value);
    }
}
