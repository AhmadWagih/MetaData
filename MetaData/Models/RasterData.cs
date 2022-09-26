namespace MetaData.Models
{
    public class RasterData
    {
        public int Id { get; set; }
        public ERasterFormat RasterFormat { get; set; }
        public bool isGeoReferenced { get; set; }
    }
    public class RasterDataDTO
    {
        public int RasterFormat { get; set; }
        public bool isGeoReferenced { get; set; }
    }
    public enum ERasterFormat
    {
        tiff = 0,
        jpg = 1,
        bmp = 2,
        sid=3
    }
}

