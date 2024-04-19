using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcarGUI
{
    public static class Core
    {
        public static readonly Keys KeyUp = Keys.W;
        public static readonly Keys KeyDown = Keys.S;
        public static readonly Keys KeyRight = Keys.D;
        public static readonly Keys KeyLeft = Keys.A;

        public static bool IsUp = false;
        public static bool IsDown = false;
        public static bool IsRight = false;
        public static bool IsLeft = false;


    }
}