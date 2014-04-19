using MapsAgo.Model;
using System.Linq;

namespace MapsAgo.Data
{
    interface ILocationRepository
    {
        IQueryable<Location> Locatoins { get; }
    }
}
