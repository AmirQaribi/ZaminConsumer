using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;

namespace ZaminConsumer.Services;

public class GroupMemberDeleteQueryHandler(ZaminServices zaminServices, ICommandRepository<GroupMember, int> repository) : CommandHandler<GroupMemberDelete>(zaminServices)
{
    public override async Task<CommandResult> Handle(GroupMemberDelete command)
    {
        var groupMember = await repository.GetGraphAsync(command.Id) ?? throw new InvalidEntityStateException("یافت نشد");
        repository.Delete(groupMember);
        await repository.CommitAsync();
        return Ok();
    }
}