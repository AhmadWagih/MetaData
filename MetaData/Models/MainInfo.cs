using Microsoft.EntityFrameworkCore;

namespace MetaData.Models
{
    public class MainInfo
    {
        public MainInfo()
        {
            CreatedOn = DateTime.Now;
            VectorData = new VectorData();
            RasterData = new RasterData();
            SatelliteData = new SatelliteData();
            IsDeleted=false;
        }
        public int Id { get; set; }
        public string Dept { get; set; }
        public string ProjName { get; set; }
        public string LvlOfDetails { get; set; }
        public EDataSource DataSource { get; set; }
        public string Coverage { get; set; }
        public string CoverageEntity { get; set; }
        public int Scale { get; set; }
        public string Coord { get; set; }
        public string Projection { get; set; }
        public string Acqdate { get; set; }
        public EDataType DataType { get; set; }
        public DateTime CreatedOn { get; set; }
        public int userId { get; set; }
        public VectorData VectorData { get; set; }
        public RasterData RasterData { get; set; }
        public SatelliteData SatelliteData { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class MainInfoDTO 
    {
        public string Dept { get; set; }
        public string ProjName { get; set; }
        public string LvlOfDetails { get; set; }
        public int DataSource { get; set; }
        public string Coverage { get; set; }
        public string CoverageEntity { get; set; }
        public int Scale { get; set; }
        public string Coord { get; set; }
        public string Projection { get; set; }
        public string Acqdate { get; set; }
        public int DataType { get; set; }
        public VectorDataDTO VectorData { get; set; }
        public RasterDataDTO RasterData { get; set; }
        public SatelliteDataDTO SatelliteData { get; set; }
    }
    public enum EDataSource
    {
        ESA=0,
        CAPMAS=1,
        MSA=2,
        UNDP=3
    }
    public enum EDataType
    {
        vector=0,
        raster=1,
        satellite=2
    }
}