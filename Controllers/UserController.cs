using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.User)]
public class UserController : MasterController
{
    [HttpGet("getById")]
    public async Task<IActionResult> GetById(UserGetByIdRequest query) => await Query<UserGetByIdRequest, UserQueryResponse?>(query);

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreate command) => await Create<UserCreate, Guid>(command);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserUpdate command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] UserDelete command) => await base.Delete(command);

    [HttpPost("join")]
    public async Task<IActionResult> JoinGroup([FromBody] UserJoinGroup command) => await Create<UserJoinGroup, Guid>(command);

    [HttpDelete("leave")]
    public async Task<IActionResult> LeaveGroup([FromBody] UserLeaveGroup command) => await Delete(command);
}
