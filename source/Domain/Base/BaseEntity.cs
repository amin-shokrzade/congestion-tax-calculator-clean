using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Base
{
    public abstract class BaseEntity
    {
        private readonly List<BaseEvent> _domainEvents = new List<BaseEvent>();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddEvent(BaseEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveEvent(BaseEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }

        public Guid Id { get; set; }

        public bool Deleted { get; set; }

    }
}
