


using MediatR;

namespace Project.Entities.Event;




public interface IDomainEvent : INotification { }

public abstract class Entity{

    //private Guid EntityId = Guid.NewGuid();
    private  List<INotification>? _domainEvents;
    public List<INotification>? DomainEvents => _domainEvents;


    public void RaiseDomainEvent(INotification eventItem){
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

   
    public void RemoveDomainEvent(INotification eventItem){
        _domainEvents?.Remove(eventItem);
    }


    public void ClearDomainEvents(){
        _domainEvents?.Clear();
    }

}