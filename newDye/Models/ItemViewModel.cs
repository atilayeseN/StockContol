using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newDye.Models
{
    public class ItemViewModel
    {
        public Guid ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string Color { get; set; }
        public decimal ItemPrice { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}