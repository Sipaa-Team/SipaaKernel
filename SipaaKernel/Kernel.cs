using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using SipaaKernel.System;
using SipaaKernel.System.Drivers;
using SipaaKernel.System.Shell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;

namespace SipaaKernel
{
    public class Kernel : Sys.Kernel
    {
        /// <summary>
        /// Show the PSOD (Purple Screen of Death) (only use this when a exception occurs.
        /// </summary>
        /// <param name="msg">The exception message</param>
        public static void PSOD(String msg)
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
            Console.WriteLine("    Please report this exception to the Sipaa Team (github.com/Sipaa-Team).");
            Console.WriteLine("    ");
            Console.WriteLine("    Press any key to reboot.");
            Console.WriteLine("    ");
            Console.WriteLine("    ");
            Console.ReadKey();
            Sys.Power.Reboot();
        }
        protected override void BeforeRun()
        {
            // clear OS first boot time logs
            Console.Clear();
            // init file system
            SFS.Initialize();
            // init shell
            SipaaShell.Initialize();
        }

        protected override void Run()
        {
            try
            {
                SipaaShell.GetImput();
            } catch(Exception e)
            {
                // Exception occured, disable GUI and show the PSOD

                PSOD(e.Message);
            }
        }

        public static void Wait(int milliseconds)
        {
            Cosmos.HAL.Global.PIT.Wait((uint)milliseconds);
        }
    }
}
