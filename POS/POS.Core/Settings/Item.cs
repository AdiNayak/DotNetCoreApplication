using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Settings
{
   public partial class Item:Brand
    {       
        public int BrandId { get; set; }
        public string ItemName { get; set; }
        public int MUnitId { get; set; }
      
    }
}
