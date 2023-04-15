using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Settings
{
    public partial class Party : Base
    {
        public string PartyName { get; set; }
        public string GstinNo { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        
    }
}
