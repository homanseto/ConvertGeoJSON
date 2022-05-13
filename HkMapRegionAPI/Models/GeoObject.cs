

namespace GeoJSONAPI.Models
{


    public class GeoObject: Geometry
    {
        public string type { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public Crs? crs { get; set; }
        public List<Feature> features { get; set; } = new List<Feature>();


        public class Crs
        {
            public string type { get; set; } = string.Empty;
            public CrsProperties? crsProperties { get; set; }
        }

        public class CrsProperties
        {
            public string name { get; set; } = string.Empty;
        }

        public class Feature
        {
            public string type { get; set; } = string.Empty;
            public Properties? properties { get; set; } = new Properties();
            public Geometry geometry { get; set; }   
        }

        public class Properties
        {
            public int ObjectID { get; set; }
            public string Region { get; set; } = string.Empty;
            public string District { get; set; } = string.Empty;
            public int Area1_SSMS { get; set; }
            public string Area1_Enam { get; set; } = string.Empty;
            public string Area1_Cnam { get; set; } = string.Empty;
            public int Area2_SSMS { get; set; }
            public string Area2_Enam { get; set; } = string.Empty;
            public string Area2_Cnam { get; set; } = string.Empty;
            public int Area_ID { get; set; }
            public string Area1_Feat { get; set; } = string.Empty;
            public string Area2_Feat { get; set; } = string.Empty;
            public float Shape_Leng { get; set; }
            public float Shape_Area { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

    }


}
