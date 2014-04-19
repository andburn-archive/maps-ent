using MapsAgo.Model;
using System.Linq;

namespace MapsAgo.Data
{
    interface IMediaRepository
    {
        IQueryable<Media> MediaList { get; }
    }
}
