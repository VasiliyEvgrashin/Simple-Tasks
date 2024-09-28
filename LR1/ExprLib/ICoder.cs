using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprLib
{
    public interface ICoder
    {
        int Decode(string s);
        string Encode(int d);
    }
}
