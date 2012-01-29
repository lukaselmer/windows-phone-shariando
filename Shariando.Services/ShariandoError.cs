using System.Runtime.Serialization;

namespace Shariando.Services
{
    [DataContract]
    public class ShariandoError
    {
        [DataMember(Name = "error")]
        public string Error { get; set; }
    }
}