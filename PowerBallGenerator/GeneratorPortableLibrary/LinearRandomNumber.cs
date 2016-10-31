using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorPortableLibrary
{
    public class LinearRandomNumber
    {
        private const long a = 25214903917;
        private const long c = 11;
        private long seed;


        public LinearRandomNumber(int seed)
        {
            if (seed < 0)
                this.seed = 4587445;
            else
                this.seed = seed;
        }


        public int Next(int bits)
        {
            seed = (seed *a +c) & ((1L << 48) - 1);
            return (int)(seed >> (48 - bits));
        }
    }
}
