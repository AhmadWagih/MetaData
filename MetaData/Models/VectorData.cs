namespace MetaData.Models
{
    public class VectorData
    {
        public int Id { get; set; }
        public EVectorFormat VectorFormat { get; set; }
        public string Layers { get; set; }

    }
    public class VectorDataDTO
    {
        public int VectorFormat { get; set; }
        public string Layers { get; set; }

    }
    public enum EVectorFormat
    {
        shapeFile=0,
        geoDatabase=1,
        DWG=2
    }
}
