using System.Collections.Generic;
using System.Linq;

namespace MvcApplication.Models
{
    public class SandboxModel
    {
        public SandboxModel()
        {
            PubCodes = new List<SelectListItem>
                           {
                               new SelectListItem { Value = 0, Text = "Agora", Type = 1 }, 
                               new SelectListItem { Value = 96, Text = "AGF - Agora Financial", Type = 2 }, 
                               new SelectListItem { Value = 81, Text = "CSP - Common Sense Publishing", Type = 2 }, 
                               new SelectListItem { Value = 136, Text = "HSI - Health Sciences Institute", Type = 2 },
                               new SelectListItem { Value = 0, Text = "Non-Agora", Type = 1 },
                               new SelectListItem { Value = 135, Text = "ANG - Angel Publishing", Type = 2 }, 
                               new SelectListItem { Value = 123, Text = "APF - Apocalypse Freedom", Type = 2 }, 
                               new SelectListItem { Value = 93, Text = "ASI - Asset Strategies International", Type = 2 },
                           };

            VersionNames = new List<SelectListItem>
                               {
                                   new SelectListItem { Value = 1, Text = "Alpha" },
                                   new SelectListItem { Value = 2, Text = "Beta" },
                                   new SelectListItem { Value = 3, Text = "Gamma" }
                               };

            SomeBooleanFeature = false;
        }

        public IList<SelectListGroup> Groups { get; private set; } 

        public IList<SelectListItem> PubCodes { get; private set; }

        public IList<SelectListItem> VersionNames { get; private set; }

        public SelectListItem PubCode
        {
            get { return PubCodes.Last(); }
        }

        public SelectListItem VersionName
        {
            get { return VersionNames.First(); }
        }

        public bool SomeBooleanFeature { get; set; }
    }
}