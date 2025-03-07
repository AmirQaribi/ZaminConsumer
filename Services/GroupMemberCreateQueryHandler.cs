using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;
using ZaminConsumer.Models.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static ZaminConsumer.Models.GroupMemberQuery;

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
