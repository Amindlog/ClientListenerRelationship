using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Serialize
{
    public interface IInput
    {
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }
    }
}