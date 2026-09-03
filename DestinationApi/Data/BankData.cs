using DestinationApi.Models;

namespace DestinationApi.Data
{
    public class BankData
    {
        public static List<BankConnection> Connections => new()
        {
            new ("A","B",2.00m),
            new("A","C", 1.00m),
            new("A","D", 3.00m),
            new("B","E",  2.50m),
            new("B", "F", 4.00m),
            new("C","F", 1.00m),
            new("C","G", 2.00m),
            new("D","G", 1.50m),
            new("E","I", 1.00m),
            new("A","D", 3.00m),
            new("E","J", 3.00m),
            new("F","H", 1.50m),
            new("F","I", 2.00m),
            new("G","H", 1.00m),
            new("G","I", 2.50m),
            new("H","I", 0.50m),
            new("H","J", 2.00m),
            new("I","J", 1.00m),
            new("J","K", 0.75m),
            new("K","B", 0.50m),
            new("H","C", 0.25m),
            new("I","D", 0.40m),
            new ("L","A", 1.00M)

        };
    }
}
