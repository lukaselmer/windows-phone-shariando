using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using Shariando.Services.Interfaces;
// DataContractJsonSerializer

namespace Shariando.Services
{
    [DataContract]
    public class Shop : IShop
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "shop_logo_file_name")]
        public string ImageName { get; set; }

        public string ImageUrl
        {
            get
            {
                return String.Format("https://shariando.com/upload_files/shop_logos/3/original/{0}", 
                    HttpUtility.UrlEncode(ImageName));
            }
        }

        //public Dictionary<Object, Object> Description { get; set; }

    }
}