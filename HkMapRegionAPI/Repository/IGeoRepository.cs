using GeoJSONAPI.Dto;

namespace GeoJSONAPI.Repository
{
    public interface IGeoRepository
    {
        public Task CreateGeoObject(GeoInfoForCreationDto geoInfo);
    }
}
