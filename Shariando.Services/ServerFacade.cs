using System.Collections.Generic;
using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
using System.Text;
using Shariando.Services.Interfaces;

namespace Shariando.Services
{
    public class ServerFacade : IServerFacade
    {
        public bool CheckEmail(string email)
        {
            string jsonString = "[ 1, 2, 3, 4, 5, 6 ]";
            List<int> listArray = new List<int>();

            using (MemoryStream jsonStream = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<int>));
                //List<int> array = serializer.ReadObject(jsonStream) as List<int>;
                //listArray = array;
            }

            return true;
        }

        public IList<IShop> LoadList(string email)
        {
            throw new System.NotImplementedException();
        }

        public string LinkForShop(IShop shop)
        {
            throw new System.NotImplementedException();
        }
    }
}
