using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using newDye.Models;

namespace newDye.Models
{
    public class Item
    {
        public Products Product { set; get; }
        public int Litre { set; get; }
    }
}