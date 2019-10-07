namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            // Do not fail if one record parsing fails, return null
            // TODO Implement

            if (line == null)
            {
                return null;
            }
            TacoBell trackableTacoBell = new TacoBell();
            Point Location = new Point();
            var cells = line.Split(',');

            if (cells.Length < 3 || line == null)
            {
                logger.LogError("Missing information" + line);
                return null;
            }

            bool latitudeParseSuccess = double.TryParse(cells[0], out double latitude);
            bool longitudeParseSuccess = double.TryParse(cells[1], out double longitude);

            if (latitudeParseSuccess == false || longitudeParseSuccess == false)
                return null;

            Location.Latitude = latitude;
            Location.Longitude = longitude;
            string name = cells[2];
            trackableTacoBell.Name = name;
            trackableTacoBell.Location = Location;
            return trackableTacoBell;

        }
    }
}