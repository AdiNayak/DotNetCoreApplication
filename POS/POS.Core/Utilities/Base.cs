using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
   public partial class Base
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Narration { get; set; }
        public int Status { get; set; }
    }
}
