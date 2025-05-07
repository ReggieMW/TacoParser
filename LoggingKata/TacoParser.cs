namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            
            //splits string into 3 data points, returning null if less than 3 data points
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                return null; 
            }
            
            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);
            string name = cells[2];
            
            //using point to create var for physical location to be used in GeoCoordinate
            Point point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;
            
            //instance to test that string is returned correctly
            TacoBell tacoBell = new TacoBell();
            tacoBell.Location = point;
            tacoBell.Name = name;

            return tacoBell;
        }
    }
}
