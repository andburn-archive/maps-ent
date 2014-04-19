using MapsAgo.Model;
using System.Linq;

namespace MapsAgo.Data
{
    interface IEventRepository
    {
        IQueryable<Event> Events { get; }
    }
}
