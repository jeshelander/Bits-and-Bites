using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

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

        public System.Drawing.Image ReturnImage (Byte[] incStream)
        {
            MemoryStream mems = new MemoryStream(incStream);
            return (System.Drawing.Image.FromStream(mems));
        }

        public Byte[] ReturnArray(HttpPostedFileBase incPic)
        {
            Byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                incPic.InputStream.CopyTo(ms);
                arr = ms.GetBuffer();
            }

            return arr;
        }

        public Byte[] ReturnArray(System.Drawing.Image im)
        {
            Byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr =  ms.ToArray();
            }
            return arr;
        }
    }
}