using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.User)]
public class UserController : MasterController
{
    [HttpGet("single")]
    public async Task<IActionResult> GetById(UserCommands.GetUserById query) => await Query<UserCommands.GetUserById, User.Query?>(query);

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCommands.CreateUser command) => await Create<UserCommands.CreateUser, Guid>(command);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserCommands.UpdateUser command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] UserCommands.DeleteUser command) => await base.Delete(command);

    [HttpPost("join")]
    public async Task<IActionResult> JoinGroup([FromBody] UserCommands.JoinGroup command) => await Create<UserCommands.JoinGroup, Guid>(command);

    [HttpDelete("leave")]
    public async Task<IActionResult> LeaveGroup([FromBody] UserCommands.LeaveGroup command) => await Delete(command);
}
