using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            
            var lines = File.ReadAllLines(csvPath);
            
            logger.LogInfo($"Lines: {lines[0]}");

            //reading through lines to create individual locations for GeoCoordinate
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            
            ITrackable taco1 = null;
            ITrackable taco2 = null;
            double distance = 0;
            
           //outer loop gets location for starting TacoBell, inner loop for destination. Inner loop measures the distance
           //between the two locations. If that distance is longer than the current distance, then it will become the
           //new longest distance, updating the distance and name locations. 
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    double travelMiles = corA.GetDistanceTo(corB);

                    if (travelMiles > distance)
                    {
                        distance = travelMiles;
                        taco1 = locA;
                        taco2 = locB;
                    }
                }
            }
            //the big reveal. 
            Console.WriteLine($"The longest Taco Bell roadtrip is {taco1.Name} to {taco2.Name} a distance of {distance} meters.");
        }
    }
}