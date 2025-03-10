﻿using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;
using ZaminConsumer.Utilities;

namespace ZaminConsumer.Models.Commands;

public class GroupMemberCreate : ICommand<Guid>, IWebRequest
{
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public string Path => $"/{Routes.GroupMember}";
}
