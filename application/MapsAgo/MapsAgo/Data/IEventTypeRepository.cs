using MapsAgo.Model;
using System.Linq;

namespace MapsAgo.Data
{
    interface IEventTypeRepository
    {
        IQueryable<EventType> EventTypes { get; }
    }
}
