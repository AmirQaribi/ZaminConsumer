using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Commands;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.User)]
public class UserController : MasterController
{
    [HttpGet("single")]
    public async Task<IActionResult> GetById(UserGetById query) => await Query<UserGetById, User.Query?>(query);

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCommands.UserCreate command) => await Create<UserCommands.UserCreate, Guid>(command);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserCommands.UserUpdate command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] UserCommands.UserDelete command) => await base.Delete(command);

    [HttpPost("join")]
    public async Task<IActionResult> JoinGroup([FromBody] UserCommands.UserJoinGroup command) => await Create<UserCommands.UserJoinGroup, Guid>(command);

    [HttpDelete("leave")]
    public async Task<IActionResult> LeaveGroup([FromBody] UserCommands.UserLeaveGroup command) => await Delete(command);
}
