using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataMixer
{
    public class Signature
    {
        public string Value { get; set; }
    }

    public class ObfusciousSays
    {
        public string Encrypt(Signature sig)
        {
            var hold = JsonSerializer.Serialize(sig);
            
            return hold;
        }
    }
}