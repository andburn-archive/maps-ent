using MapsAgo.Model;
using System.Linq;

namespace MapsAgo.Data
{
    interface IMediaRepository
    {
        IQueryable<Resource> MediaList { get; }
    }
}
