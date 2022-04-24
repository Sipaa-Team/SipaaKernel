using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernel.System.Drivers;

namespace SipaaKernel.System.Shell.Commands.System
{
    class StartGUICommand : Command
    {
        public StartGUICommand()
        {
            this.Name = "startgui";
            this.UppercaseName = "STARTGUI";
            this.Description = "Start the GUI, No arguments needed.";
        }

        public override void Execute(string[] args)
        {
            // init driver
            SGSD.Initialize();

            // for tests only
            Console.ReadKey();
            SGSD.StopDriver();
            base.Execute(args);
        }
    }
}
