using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.Group)]
public class GroupController : MasterController
{
    [HttpGet("single")]
    public async Task<IActionResult> GetById(GroupCommands.GetGroupById query) => await Query<GroupCommands.GetGroupById, Group.Query?>(query);

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] GroupCommands.CreateGroup command) => await Create<GroupCommands.CreateGroup, Guid>(command);

    [HttpPut]
    public async Task<IActionResult> UpdateGroup([FromBody] GroupCommands.UpdateGroup command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> DeleteBlog([FromBody] GroupCommands.DeleteGroup command) => await Delete(command);
}
