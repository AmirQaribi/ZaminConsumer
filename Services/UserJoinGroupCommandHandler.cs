using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;

namespace ZaminConsumer.Services;

public class UserJoinGroupCommandHandler(ZaminServices zaminServices, ICommandRepository<GroupMember, int> repository) : CommandHandler<UserJoinGroup, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(UserJoinGroup command)
    {
        var groupMembers = GroupMember.Create(command.UserId, command.GroupId);
        await repository.InsertAsync(groupMembers);
        await repository.CommitAsync();
        return Ok(groupMembers.BusinessId.Value);
    }
}

//public class UserLeaveGroupCommandHandler(ZaminServices zaminServices, ICommandRepository<GroupMember, int> repository) : CommandHandler<UserLeaveGroup>(zaminServices)
//{
//    public override async Task<CommandResult> Handle(UserLeaveGroup command)
//    {
//        UserGetByIdQueryHandler()
//        var user = await repository.GetGraphAsync(command.Id) ?? throw new InvalidEntityStateException("کاربر یافت نشد");
//        user.Delete();
//        repository.Delete(user);
//        await repository.CommitAsync();
//        return Ok();
//    }
//}