using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Commands;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.Group)]
public class GroupController : MasterController
{
    [HttpGet("single")]
    public async Task<IActionResult> GetById(GroupCommands.GroupGetById query) => await Query<GroupCommands.GroupGetById, Group.Query?>(query);

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] GroupCommands.GroupCreate command) => await Create<GroupCommands.GroupCreate, Guid>(command);

    //[HttpPut]
    //public async Task<IActionResult> UpdateGroup([FromBody] GroupCommands.UpdateGroup command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> DeleteGroup([FromBody] GroupCommands.GroupDelete command) => await Delete(command);
}
