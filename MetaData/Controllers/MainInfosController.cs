using MetaData.DB;
using MetaData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace MetaData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainInfosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MainInfosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAllInfos()
        {
            List<MainInfo> MainInfos = _context.MainInfos.Include(inf => inf.VectorData).Include(inf => inf.RasterData).Include(inf => inf.SatelliteData).Where(inf => !inf.IsDeleted).ToList();
            return Ok(MainInfos);
        }
        [HttpPost]
        public IActionResult AddInfo(MainInfoDTO info)
        {
            // need user Id
            if (info != null)
            {
                MainInfo mainInfo = new MainInfo()
                {
                    Dept = info.Dept,
                    ProjName = info.ProjName,
                    LvlOfDetails = info.LvlOfDetails,
                    DataSource = (EDataSource)info.DataSource,
                    Coverage = info.Coverage,
                    CoverageEntity = info.CoverageEntity,
                    Scale = info.Scale,
                    Acqdate = info.Acqdate,
                    Projection = info.Projection,
                    Coord = info.Coord,
                    DataType = (EDataType)info.DataType
                };
                switch (mainInfo.DataType)
                {
                    case EDataType.vector:
                        mainInfo.VectorData.VectorFormat = (EVectorFormat)info.VectorData.VectorFormat;
                        mainInfo.VectorData.Layers = info.VectorData.Layers;
                        break;
                    case EDataType.raster:
                        mainInfo.RasterData.RasterFormat = (ERasterFormat)info.RasterData.RasterFormat;
                        mainInfo.RasterData.isGeoReferenced = info.RasterData.isGeoReferenced;
                        break;
                    case EDataType.satellite:
                        mainInfo.SatelliteData.SatelliteFormat = (ESatelliteFormat)info.SatelliteData.SatelliteFormat;
                        mainInfo.SatelliteData.Resolution = info.SatelliteData.Resolution;
                        mainInfo.SatelliteData.isGeoReferenced = info.SatelliteData.isGeoReferenced;
                        break;
                    default:
                        return NotFound("Error");
                }
                _context.Add(mainInfo);
                _context.SaveChanges();
                return Ok("Added Successfully");
            }
            else
            {
                return NotFound("Error");
            }
        }

        [HttpPut("{infoId}")]
        public IActionResult editInfo(int infoId, MainInfoDTO newInfo)
        {

            if (newInfo != null)
            {
                MainInfo mainInfo = _context.MainInfos.FirstOrDefault(inf => inf.Id == infoId);
                if (mainInfo == null)
                {
                    return NotFound("Error");
                }
                mainInfo.Dept = newInfo.Dept;
                mainInfo.ProjName = newInfo.ProjName;
                mainInfo.LvlOfDetails = newInfo.LvlOfDetails;
                mainInfo.DataSource = (EDataSource)newInfo.DataSource;
                mainInfo.Coverage = newInfo.Coverage;
                mainInfo.CoverageEntity = newInfo.CoverageEntity;
                mainInfo.Scale = newInfo.Scale;
                mainInfo.Acqdate = newInfo.Acqdate;
                mainInfo.Projection = newInfo.Projection;
                mainInfo.Coord = newInfo.Coord;
                // remove old DataType
                if (mainInfo.DataType != (EDataType)newInfo.DataType)
                {
                    mainInfo.VectorData = null;
                    mainInfo.RasterData = null;
                    mainInfo.SatelliteData = null;
                }
                mainInfo.DataType = (EDataType)newInfo.DataType;
                switch (mainInfo.DataType)
                {
                    case EDataType.vector:
                        mainInfo.VectorData = new VectorData()
                        {
                            VectorFormat = (EVectorFormat)newInfo.VectorData.VectorFormat,
                            Layers = newInfo.VectorData.Layers
                        };
                        break;
                    case EDataType.raster:
                        mainInfo.RasterData = new RasterData()
                        {
                            RasterFormat = (ERasterFormat)newInfo.RasterData.RasterFormat,
                            isGeoReferenced = newInfo.RasterData.isGeoReferenced
                        };
                        break;
                    case EDataType.satellite:
                        mainInfo.SatelliteData = new SatelliteData()
                        {
                            SatelliteFormat = (ESatelliteFormat)newInfo.SatelliteData.SatelliteFormat,
                            Resolution = newInfo.SatelliteData.Resolution,
                            isGeoReferenced = newInfo.SatelliteData.isGeoReferenced
                        };
                        break;
                    default:
                        return NotFound("Error");
                }

                _context.SaveChanges();
                return Ok($"Data with id :{infoId} is updated !");
            }
            else
            {
                return NotFound("Error");
            }
        }

        [HttpDelete("{infoId}")]
        public IActionResult deleteInfo(int infoId)
        {
            MainInfo mainInfo = _context.MainInfos.FirstOrDefault(inf => inf.Id == infoId);
            if (mainInfo != null)
            {
                mainInfo.IsDeleted = true;
                _context.SaveChanges();
                return Ok($"Data with id :{infoId} is deleted !");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
