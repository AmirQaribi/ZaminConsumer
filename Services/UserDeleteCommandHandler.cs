using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;

namespace ZaminConsumer.Services;

public class UserDeleteCommandHandler(ZaminServices zaminServices, ICommandRepository<User, int> repository) : CommandHandler<UserDelete>(zaminServices)
{
    public override async Task<CommandResult> Handle(UserDelete command)
    {
        var user = await repository.GetGraphAsync(command.Id) ?? throw new InvalidEntityStateException("کاربر یافت نشد");
        user.Delete();
        repository.Delete(user);
        await repository.CommitAsync();
        return Ok();
    }
}