using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System.Drivers
{
    public class SFS
    {
        public static CosmosVFS driver;

        public static void Initialize()
        {
            driver = new CosmosVFS();
            VFSManager.RegisterVFS(driver, false);
        }
    }
}
