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
        public static readonly Keys KeyCharging = Keys.C;
        public static readonly Keys KeyLights = Keys.L;
        public static readonly Keys KeyHandBrake = Keys.B;
        public static readonly Keys KeyRightBlink = Keys.OemPeriod; // >
        public static readonly Keys KeyLeftBlink = Keys.Oemcomma; // <

        public static bool IsUp = false;
        public static bool IsDown = false;
        public static bool IsRight = false;
        public static bool IsLeft = false;
        public static bool IsCharging = false;
        public static int IsLights = 0;
        public static bool IsHandBrake = false;
        public static bool IsRightBlink = false;
        public static bool IsLeftBlink = false;


    }
}