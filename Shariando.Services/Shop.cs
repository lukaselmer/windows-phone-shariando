using System.Runtime.Serialization;
using Shariando.Services.Interfaces;
// DataContractJsonSerializer

namespace Shariando.Services
{
    [DataContract]
    class Shop : IShop
    {
        [DataMember]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}