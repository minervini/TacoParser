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
            logger.LogInfo("LogInfo");
            var lines = File.ReadAllLines(csvPath);
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable TacoBell1 = null;
            ITrackable TacoBell2 = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                logger.LogInfo($"Lines: {lines[i]}");
                ITrackable LocationA = locations[i];
                var corA = new GeoCoordinate(LocationA.Location.Latitude, LocationA.Location.Longitude);

                for (int k = 0; k < i + 1; k++)
                {
                    ITrackable LocationB = locations[k];
                    var corB = new GeoCoordinate(LocationB.Location.Latitude, LocationB.Location.Longitude);
                    double distanceTest = corA.GetDistanceTo(corB);

                    if (distanceTest > distance)
                    {
                        TacoBell1 = LocationA;
                        TacoBell2 = LocationB;
                        distance = distanceTest;
                    }
                }
            }
            Console.WriteLine(TacoBell1.Name);
            Console.WriteLine(TacoBell2.Name);  
        }
    }
}