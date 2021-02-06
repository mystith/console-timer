using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace console_timer
{
    public class ConfigLoader
    {
        private IDeserializer _deserializer;
        private ISerializer _serializer;
        
        public ConfigLoader()
        {
            _deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
            _serializer = new SerializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        }
        
        public Config Load()
        {
            if (File.Exists("config.yml"))
                return _deserializer.Deserialize<Config>(File.ReadAllText("config.yml"));

            Config cfg = new Config();
            File.WriteAllText("config.yml", _serializer.Serialize(cfg));
            return cfg;
        }
    }
}