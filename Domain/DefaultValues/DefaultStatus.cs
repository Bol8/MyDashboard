using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DefaultValues
{
    public class DefaultStatus
    {
        public  static  int Active { get { return 1; } }
        public static int Disable { get { return 2; } }
    }
}
