using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;


namespace ZaminConsumer.Services;

public class GroupDeleteCommandHandler(ZaminServices zaminServices, ICommandRepository<Group, int> repository) : CommandHandler<GroupDelete>(zaminServices)
{
    public override async Task<CommandResult> Handle(GroupDelete command)
    {
        var group = await repository.GetGraphAsync(command.Id) ?? throw new InvalidEntityStateException("گروه یافت نشد");
        group.Delete();
        repository.Delete(group);
        await repository.CommitAsync();
        return Ok();
    }
}