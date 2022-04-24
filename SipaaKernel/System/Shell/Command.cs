using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System.Shell
{
    public class Command
    {
        private string _Name, _UppercaseName, _Description, _Usage;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string UppercaseName
        {
            get { return _UppercaseName; }
            set { _UppercaseName = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Usage
        {
            get { return _Usage; }
            set { _Usage = value; }
        }

        public virtual void Execute(string[] args)
        {

        }
    }
}
