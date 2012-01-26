using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;
using Shariando.Services.Interfaces;

namespace Shariando.Services
{
    [DataContract]
    public class Shop : IShop
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public TranslatedDescription AllDescriptions { get; set; }
        public string Description { get { return AllDescriptions == null ? "" : AllDescriptions.Default(); } }

        [DataMember(Name = "amount_text")]
        public string Cashback { get; set; }

        [DataMember(Name = "shop_logo_file_name")]
        public string ImageName { get; set; }


        public string ImageUrl
        {
            get
            {
                return String.Format("https://shariando.com/upload_files/shop_logos/{0}/png/{1}",
                    Id, HttpUtility.UrlEncode(ImageName.Replace(".gif", ".png")));
            }
        }

        [DataContract]
        public class TranslatedDescription
        {
            [DataMember(Name = "de")]
            public string De { get; set; }
            [DataMember(Name = "en")]
            public string En { get; set; }
            [DataMember(Name = "dk")]
            public string Dk { get; set; }
            [DataMember(Name = "fi")]
            public string Fi { get; set; }
            [DataMember(Name = "nl")]
            public string Nl { get; set; }

            public string Default()
            {
                var replacements = new Dictionary<string, string>
                    {
                        {"<br/>", "\n"},                       
                        {"<br>", "\n"},                       
                        {"<p>", "\n"},                      
                        {"</p>", ""},
                        {"<strong>", ""},                       
                        {"</strong>", ""},                       
                    };
                var arr = new List<string> { De, En, Dk, Fi, Nl, "" };
                var str = arr.First(s => !string.IsNullOrEmpty(s));
                return replacements.Aggregate(str, (current, replacement) => current.Replace(replacement.Key, replacement.Value));
            }
        }
    }

}