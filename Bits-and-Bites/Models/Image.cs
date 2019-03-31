using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
    public class Image
    {
        int Id { get; set; }
        string ImageName { get; set; }
        string ImageAlt { get; set; }
        double UsageData { get; set; }
        string ContentType { get; set; }
    }
}