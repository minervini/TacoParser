namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if (line == null)
            {
                logger.LogError("Missing information");
                return null;
            }

            var cells = line.Split(',');

            if (cells.Length < 3 || line == null)
            {
                logger.LogError("Missing information" + line);
                return null;
            }

            bool latitudeParseSuccess = double.TryParse(cells[0], out double latitude);
            bool longitudeParseSuccess = double.TryParse(cells[1], out double longitude);

            if (latitudeParseSuccess == false || longitudeParseSuccess == false)
            {
                logger.LogInfo("Fatel Error");
                return null;
            }

            TacoBell trackableTacoBell = new TacoBell();
            Point Location = new Point();

            Location.Latitude = latitude;
            Location.Longitude = longitude;
            string name = cells[2];
            trackableTacoBell.Name = name;
            trackableTacoBell.Location = Location;

            return trackableTacoBell;
        }
    }
}