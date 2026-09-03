using DestinationApi.Models;

namespace DestinationApi.Services
{
    public class RouteFinder : IRouteFinder
    {
        private readonly List<BankConnection> _connection;

        public RouteFinder(List<BankConnection> connection)
        {
            _connection = connection;
        }

        public RouteResult FindRoute(string source, string destination)
        {
            var allRoutes = new List<RouteResult>();

            FindAllRoutes(source, destination, new List<string>{source },0m,allRoutes);

            if (!allRoutes.Any()) 
            {
                return null;
            }

            var minCount = allRoutes.Min(c => c.MoveCount);

            return allRoutes.Where(r => r.MoveCount == minCount)
                .OrderBy(r => r.TotalFee).FirstOrDefault();
        }




        private void FindAllRoutes(string current, string destination, List<string> path, decimal fee, List<RouteResult> results)
        {
            if (current == destination)
            {
                results.Add(new RouteResult(path, path.Count - 1, fee));
                return;
            }

            foreach (var conn in _connection.Where(c => c.From == current && !path.Contains(c.To)))
            {
                FindAllRoutes(conn.To,
                    destination,
                    new List<string>(path) { conn.To },
                    fee + conn.Fee,
                    results);
            }
        }
    }
}
