using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;
namespace ZaminConsumer.Services;

public class GroupMemberCreateQueryHandler(ZaminServices zaminServices, ICommandRepository<GroupMember, int> repository) : CommandHandler<GroupMemberCreate, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(GroupMemberCreate command)
    {
        var groupMember = GroupMember.Create(command.UserId, command.GroupId);
        await repository.InsertAsync(groupMember);
        await repository.CommitAsync();
        return Ok(groupMember.BusinessId.Value);
    }
}
