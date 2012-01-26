using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Shariando.Services.Interfaces;

namespace Shariando.Services
{
    public class ServerFacade : IServerFacade
    {
        public void CheckEmail(string email, Action<IList<IShop>> callback)
        {
            SendPost(email);
        }

        void SendPost(string email)
        {
            string url = string.Format("https://shariando.com/shops.json?email={0}", HttpUtility.UrlEncode(email));
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        }

        void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                HttpWebResponse response;

                // End the get response operation
                response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse);
                var json = streamReader.ReadToEnd();
                streamResponse.Close();
                streamReader.Close();
                response.Close();

                ProcessJson(json);
            }
            catch (WebException e)
            {
                // Error treatment
                // ...
            }
        }

        private void ProcessJson(string json)
        {
            //json = "[{\"active\":true,\"description\":{\"de\":\"Peach ist seit mehr als 10 Jahren im Markt und ist laut GfK Marktf\u00fchrer f\u00fcr kompatible Tintenpatronen in der Schweiz. Das Programm umfasst zudem Tonermodule, Fotopapier, Refills und dies zu Preisen von bis zu 50% unter dem Preis der Originalhersteller.\n\"},\"id\":2,\"name\":\"3ppp3.ch Tintenshop\",\"shop_logo_file_name\":\"642e92efb79421734881b53e1e1b18b6.gif\"}]";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Shop>));
            using (MemoryStream jsonStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                List<Shop> shops = (List<Shop>)serializer.ReadObject(jsonStream);
                IList<IShop> res = shops.Cast<IShop>().ToList();
                Console.WriteLine(res);
            }
        }


    }
}
