
namespace Domain.Base
{
    public abstract class BaseEntityWithAudit : BaseEntity
    {
        public DateTimeOffset CreatedOn { get; set; }

        public Guid? Creator { get; set; }

        public DateTimeOffset ModifiedOn { get; set; }

        public Guid? Modifier { get; set; }
    }
}
