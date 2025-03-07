using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.Group)]
public class GroupController(QueryDbContext queryContex) : MasterController
{
    private readonly QueryDbContext _queryContext = queryContex;

    [HttpGet()]
    public ActionResult<List<Group>> GetAll() => Ok(_queryContext.Groups.ToList());

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(GroupGetByIdRequest query) => await Query<GroupGetByIdRequest, GroupQueryResponse?>(query);

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] GroupCreate command) => await Create<GroupCreate, Guid>(command);

    //[HttpPut]
    //public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroup command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> DeleteGroup([FromBody] GroupDelete command) => await Delete(command);
}
