using Newtonsoft.Json;

namespace GeoJSONAPI.Utilities
{
    public class JsonFile
    {
        public T? LoadJson<T>(string path)
        {
            using(StreamReader r= new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
