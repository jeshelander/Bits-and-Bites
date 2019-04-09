using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageAlt { get; set; }
        public double UsageData { get; set; }
        public string ContentType { get; set; }
        public Byte[] StoredImage { get; set; }
    }
}