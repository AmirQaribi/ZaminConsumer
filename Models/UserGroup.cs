using Zamin.Core.Domain.Entities;

namespace ZaminConsumer.Models
{
    public class UserGroup : AggregateRoot<int>
    {
        public User? User { get; set; }
        public Group? Group { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public UserGroup(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }

        public static UserGroup Create(int userId, int groupId) => new(userId, groupId);
    }
}
