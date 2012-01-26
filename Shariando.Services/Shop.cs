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
                return "http://www.elmermx.ch/typo3temp/pics/1951305aaf.jpg";
                return
                    "https://shariando.com/upload_files/shop_logos/12/original/a1d0c6e83f027327d8461063f4ac58a6.gif?1316176208";
                return String.Format("https://shariando.com/upload_files/shop_logos/{0}/original/{1}",
                    Id, HttpUtility.UrlEncode(ImageName));
            }
        }

        public BitmapImage Image
        {
            get
            {
                var image = new BitmapImage();
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