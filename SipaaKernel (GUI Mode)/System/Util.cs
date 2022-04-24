using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System
{
    public class Util
    {
        public static int GetStringWidth(string str, Font font)
        {

            return str.Length * font.Width;
        }
    }
}
