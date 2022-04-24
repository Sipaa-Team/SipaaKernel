using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System.Shell.Commands.System
{
    class ThrowPSODCommand : Command
    {
        public ThrowPSODCommand()
        {
            this.Name = "throwpsod";
            this.UppercaseName = "THROWPSOD";
            this.Description = "Throws a PSOD, No argument needed.";
        }
        public override void Execute(string[] args)
        {
            Kernel.PSOD("Test");
            base.Execute(args);
        }
    }
}
