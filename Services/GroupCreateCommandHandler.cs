using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Commands;
using ZaminConsumer.Models;
using static ZaminConsumer.Commands.GroupCommands;

namespace ZaminConsumer.Services;

public class GroupCreateCommandHandler(ZaminServices zaminServices, ICommandRepository<Group, int> Repository) : CommandHandler<GroupCreate, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(GroupCreate command)
    {
        Group group = Group.Create(command.Title);

        await Repository.InsertAsync(group);

        await Repository.CommitAsync();
        Console.WriteLine("Yo3 {0}", group.BusinessId.Value.ToString());
        return Ok(group.BusinessId.Value);
    }
}
