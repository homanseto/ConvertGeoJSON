using GeoJSONAPI.Models;

namespace GeoJSONAPI.Dto
{
    public class GeoInfoForCreationDto: Geometry
    {
        public int ObjectID { get; set; }
        public string Region { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Area2_Enam { get; set; } = String.Empty;
        public string Area2_Cnam { get; set; } = String.Empty;
        public double Lat { get; set; } 
        public double Lon { get; set; }
        public string Boundary { get; set; } = String.Empty;
    }
}
