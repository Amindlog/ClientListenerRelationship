using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Serialize
{
    public class Output : IOutput
    {
        public decimal SumResult { get ; set ; }
        public int MulResult { get ; set ; }
        public decimal[] SortedInputs { get ; set ; }
    }
}