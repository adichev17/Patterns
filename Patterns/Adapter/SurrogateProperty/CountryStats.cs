using System.Xml.Serialization;


//XmlSerialiable can`t serial. dictionary.
namespace Patterns.Adapter.SurrogateProperty
{
    public class CountryStats
    {
        [XmlIgnore]
        public Dictionary<string, string> Capitals { get; set; } = new Dictionary<string, string>();

        public (string, string)[] CapitalsSerializable
        {
            get
            {
                return Capitals.Keys.Select(country =>
                  (country, Capitals[country])).ToArray();
            }
            set
            {
                Capitals = value.ToDictionary(x => x.Item1, x => x.Item2);
            }
        }
    }

}
