using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;
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
                return String.Format("https://shariando.com/upload_files/shop_logos/{0}/png/{1}",
                    Id, HttpUtility.UrlEncode(ImageName.Replace(".gif", ".png")));
            }
        }

        public BitmapImage Image
        {
            get
            {
                //var image = new BitmapImage();
                /*image.BeginInit();
                image.StreamSource = File.OpenRead(ImageUrl);
                image.EndInit();
                image.Freeze();
                return image;*/
                return new BitmapImage(new Uri(ImageUrl, UriKind.Absolute));
            }
        }


        //public Dictionary<Object, Object> Description { get; set; }

    }
}