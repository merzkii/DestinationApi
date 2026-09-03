using DestinationApi.Models;

namespace DestinationApi.Services
{
    public interface IRouteFinder
    {
        RouteResult FindRoute(string source, string destination);
    }
}
