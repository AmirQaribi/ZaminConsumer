using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.Group)]
public class GroupController : MasterController
{
    [HttpGet("single")]
    public async Task<IActionResult> GetById(GroupCommands.GetById query) => await Query<GroupCommands.GetById, Group.Query?>(query);

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] GroupCommands.Create command) => await Create<GroupCommands.Create, Guid>(command);

    [HttpPut]
    public async Task<IActionResult> UpdateGroup([FromBody] GroupCommands.Update command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> DeleteBlog([FromBody] GroupCommands.Delete command) => await Delete(command);
}
