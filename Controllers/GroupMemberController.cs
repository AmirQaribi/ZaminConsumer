using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.GroupMember)]
public class GroupMemberController(QueryDbContext queryContex) : MasterController
{
    private readonly QueryDbContext _queryContext = queryContex;
    [HttpGet()] public ActionResult<List<GroupMember>> GetAll() => Ok(_queryContext.GroupMembers.ToList());

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(GroupMemberGetByIdRequest query) => await Query<GroupMemberGetByIdRequest, GroupMemberQueryResponse?>(query);

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] GroupMemberCreate command) => await Create<GroupMemberCreate, Guid>(command);

    [HttpDelete()]
    public async Task<IActionResult> Delete([FromBody] GroupMemberDelete command) => await base.Delete(command);
}
