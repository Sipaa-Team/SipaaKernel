using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System
{
    public class Information
    {
        // Variables (for properties)
        private static string _OSName = "SipaaKernel";
        private static string _VersionNumber = "0";
        private static string _VersionRevision = "1";
        private static bool _IsFinished = false;
        // Properties
        public static string OSName
        {
            get { return _OSName; }
        }
        public static bool IsCompleted
        {
            get { return _IsFinished; }
        }

        public static string OSVersion
        {
            get { return _VersionNumber; }
        }

        public static string OSRevision
        {
            get { return _VersionRevision; }
        }
        // Functions
        public static int GetVersionInt()
        {
            return int.Parse(OSVersion);
        }
        public static int GetRevisionInt()
        {
            return int.Parse(OSRevision);
        }
        public static double GetVersionAndRevisionDouble()
        {
            return double.Parse(_VersionNumber + "." + _VersionRevision);
        }
        public static string GetVersionAndRevision()
        {
            return _VersionNumber + "." + _VersionRevision;
        }
    }
}
