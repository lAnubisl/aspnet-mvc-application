using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class SelectListGroup
    {
        public string Name { get; set; }

        public IList<SelectListItem> Items { get; set; }
    }
}