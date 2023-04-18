using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tais.Models.Messages
{
    class MESSAG_DAY_INC
    {
        public readonly int year;
        public readonly int month;
        public readonly int day;

        public MESSAG_DAY_INC(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
    }
}
