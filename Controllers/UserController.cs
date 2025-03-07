using Microsoft.AspNetCore.Mvc;
using ZaminConsumer.Models;
using ZaminConsumer.Models.Commands;
using ZaminConsumer.Models.Queries;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Controllers;

[Route(Routes.User)]
public class UserController(QueryDbContext queryContex) : MasterController
{
    private readonly QueryDbContext _queryContext = queryContex;

    [HttpGet()]
    public ActionResult<List<User>> GetAll() => Ok(_queryContext.Users.ToList());

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(UserGetByIdRequest query) => await Query<UserGetByIdRequest, UserQueryResponse?>(query);

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreate command) => await Create<UserCreate, Guid>(command);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserUpdate command) => await Edit(command);

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] UserDelete command) => await base.Delete(command);
}
