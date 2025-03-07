using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;

namespace ZaminConsumer.Services;

public class UserUpdateCommandHandler(ZaminServices zaminServices, ICommandRepository<User, int> repository) : CommandHandler<UserUpdate>(zaminServices)
{
    public override async Task<CommandResult> Handle(UserUpdate command)
    {
        var user = await repository.GetAsync(command.Id) ?? throw new InvalidEntityStateException("کاربر یافت نشد");
        user.Update(command.Username, command.Age);
        await repository.CommitAsync();
        return Ok();
    }
}