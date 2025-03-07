namespace ZaminConsumer.Models;

public class GroupMemberQuery
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; } 
    public string? CreatedByUserId { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public Guid BusinessId { get; set; }
    public List<GroupMemberQuery>? GroupMembers { get; set; }

    //public interface IGroupMemberQueryRepository { public Task<Query?> ExecuteAsync(FindGroupMemberId query); }
}
