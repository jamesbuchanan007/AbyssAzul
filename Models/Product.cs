using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace AbyssAzul.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string LatinName { get; set; }
        public string Size { get; set; }
        public string Presentation { get; set; }
        public string ProcessPacking { get; set; }
        public string Origin { get; set; }
        public string Region { get; set; }
        public CommonNames CommonNames { get; set; }
        public Images Images { get; set; }
    }
}