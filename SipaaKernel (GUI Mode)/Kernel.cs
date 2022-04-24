using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using SipaaKernel.System;
using SipaaKernel.System.Drivers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;

namespace SipaaKernel
{
    public class Kernel : Sys.Kernel
    {
        public static PCScreenFont font;
        public static bool Debug = true;
        /// <summary>
        /// Show the PSOD (Purple Screen of Death) (only use this when a exception occurs.
        /// </summary>
        /// <param name="msg">The exception message</param>
        public static void PSOD(Exception e)
        {
            if (!Debug)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("    ");
                Console.WriteLine("    :(");
                Console.WriteLine("    ");
                Console.WriteLine("    A fatal error has occurred in SipaaKernel.");
                Console.WriteLine("    We are sorry.");
                Console.WriteLine("    ");
                Console.WriteLine("    " + e.Message);
                Console.WriteLine("    ");
                Console.WriteLine("    Please report this exception to the Sipaa Team (github.com/Sipaa-Team).");
                Console.WriteLine("    ");
                Console.WriteLine("    Press any key to reboot.");
                Console.WriteLine("    ");
                Console.WriteLine("    ");
                Console.ReadKey();
                Sys.Power.Reboot();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("SipaaKernel error.");
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.StackTrace);
            }
        }
        protected override void BeforeRun()
        {
            // clear OS first boot time logs
            Console.Clear();
            // init file system
            SFS.Initialize();

            SGSD.Initialize();
        }

        protected override void Run()
        {
            try
            {
                var str = Information.OSName + " " + Information.GetVersionAndRevision();
                SGSD.Screen.DrawString(str, font, new Pen(Color.White), ((int)SGSD.Width / 2) - ((int)Util.GetStringWidth(str, font) / 2), 0);

                SGSD.DisplayScreen();
            }
            catch (Exception e)
            {
                // Exception occured, disable GUI and show the PSOD
                SGSD.StopDriver();

                PSOD(e);
            }
        }

        public static void Wait(int milliseconds)
        {
            Cosmos.HAL.Global.PIT.Wait((uint)milliseconds);
        }
    }
}
