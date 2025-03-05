using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace ZaminConsumer.Models
{
    public class Group : AggregateRoot<int>
    {
        #region Properties
        public Title Title { get; private set; }
        public IReadOnlyList<UserGroup> UserGroups => [.. _userGroups];
        private readonly List<UserGroup> _userGroups = [];
        #endregion

        public Group(Title title)
        {
            Title = title;
            //AddEvent(new BlogCreated(BusinessId.Value, Zamin.Core.Domain.Toolkits.ValueObjects.Title.Value, Description.Value));
        }
        public static Group Create(Title title) => new(title);

        public void Update(Title title)
        {
            Title = title;
            //AddEvent(new BlogUpdated(BusinessId.Value, Zamin.Core.Domain.Toolkits.ValueObjects.Title.Value, Description.Value));
        }
        public void Delete()
        {
            if (_userGroups.Count != 0)
                throw new InvalidEntityStateException("این گروه دارای یک یا چند کاربر است");

            //AddEvent(new BlogDeleted(BusinessId.Value));
        }

        public class Query
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
        }
    }
}
