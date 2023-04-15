using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Settings
{
  public partial  class Product:Brand
    {
        public int BrandId { get; set; }
         public string ProductName { get; set; }
    }
}
