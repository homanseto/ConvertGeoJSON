using GeoJSONAPI.Context;
using GeoJSONAPI.Dto;
using GeoJSONAPI.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace GeoJSONAPI.Repository
{
    public class GeoRepository 
    {
        private readonly DapperContext _context;
        public GeoRepository(DapperContext context)
        {
            _context = context;
        }

        public void CreateGeoObject(GeoObject geoObject)
        {
            var query = "INSERT INTO RegionDistrictAreaHk(ObjectID, Region, District, Area2_Enam, Area2_Cnam, Lat, Lon, Boundary)" +
                        "SELECT @ObjectID, @Region, @District, @Area2_Enam, @Area2_Cnam, @Lat, @Lon, @Boundary";
            var geoInfoDtoList = new List<GeoInfoForCreationDto>();
            var features = geoObject.features;
            foreach(var feature in features)
            {
                var geoInfoDto = new GeoInfoForCreationDto();
                geoInfoDto.ObjectID = feature.properties.ObjectID;
                geoInfoDto.Region = feature.properties.Region;
                geoInfoDto.District = feature.properties.District;
                geoInfoDto.Area2_Enam = feature.properties.Area2_Enam;
                geoInfoDto.Area2_Cnam = feature.properties.Area2_Cnam;
                geoInfoDto.Lat = feature.properties.Lat;
                geoInfoDto.Lon = feature.properties.Lon;
               // geoInfoDto.geometry.type = feature.geometry.type;
                var coordinates = feature.geometry.coordinates[0];
                string doubleBracket = "(({0}))";
                if (coordinates.Count > 1)
                {
                    string templateString = "geometry::Parse('{0} ({1})');";
                    List<string> multiPolygon = new List<string>();
                    foreach(var a in coordinates)
                    {
                        string singlePolygon;
                        List<string> latLongList = new List<string>();
                        foreach (var b in a)
                        {
                            
                            string latlong = String.Join(" ", b);
                            latLongList.Add(latlong);
                        }
                        singlePolygon = String.Format(doubleBracket, string.Join(",", latLongList));
                        multiPolygon.Add(singlePolygon);
                    }
                    geoInfoDto.Boundary = String.Format(templateString, "MultiPolygon", String.Join(",", multiPolygon));
                }
                else
                {
                    string templateString = "geometry::Parse('{0} {1}');";
                    List<string> latLongList = new List<string>();
                    foreach (var a in coordinates[0])
                    {
                        string latlong = String.Join(" ", a);
                        latLongList.Add(latlong);
                    }
                    geoInfoDto.Boundary = String.Format(templateString, "Polygon", String.Format(doubleBracket, string.Join(",", latLongList)));
                }


                geoInfoDtoList.Add(geoInfoDto);
            }

            using (var connection = _context.CreateConnection())
            {

                foreach (var item in geoInfoDtoList)
                {
                    connection.Execute(query.Replace("@Boundary", item.Boundary), item);
                }
            }

        }
    }
}
