namespace MetaData.Models
{
    public class SatelliteData
    {

        public int Id { get; set; }
        public ESatelliteFormat SatelliteFormat { get; set; }
        public int Resolution { get; set; }
        public bool isGeoReferenced { get; set; }
    }
    public class SatelliteDataDTO
    {
        public int SatelliteFormat { get; set; }
        public int Resolution { get; set; }
        public bool isGeoReferenced { get; set; }
    }

    public enum ESatelliteFormat
    {
        IKONOS = 0,
        QUICKBIRD = 1,
        LANDSAT = 2,
        Spot = 3
    }
}
