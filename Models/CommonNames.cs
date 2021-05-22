using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace AbyssAzul.Models
{
    public class CommonNames
    {
        public int CommonNameId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}