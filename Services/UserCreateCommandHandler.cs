using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;

namespace ZaminConsumer.Services;

public class UserCreateCommandHandler(ZaminServices zaminServices, ICommandRepository<User, int> repository) : CommandHandler<UserCreate, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(UserCreate command)
    {
        var group = User.Create(command.Username, command.Age);
        await repository.InsertAsync(group);
        await repository.CommitAsync();
        return Ok(group.BusinessId.Value);
    }
}