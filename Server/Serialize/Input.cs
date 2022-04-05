using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Serialize
{
    public class Input
    {
        // {"K":10,"Sums":[1.01,2.02],"Muls":[1,4]}
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }
    }
}