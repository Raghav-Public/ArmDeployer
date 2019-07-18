using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace ArmDeployer
{
    public class AppName
    {
        public string value { get; set; }
        public AppName(string appName)
        {
            this.value = appName;
        }
    }

    public class AppType
    {
        public string value { get; set; }
        public AppType(string appType)
        {
            this.value = appType;
        }
    }

    public class AppLocation
    {
        public string value { get; set; }
        public AppLocation(string appLocation)
        {
            this.value = appLocation;
        }
    }

    public class Parameters
    {
        public AppName appName { get; set; }
        public AppType appType { get; set; }
        public AppLocation appLocation { get; set; }

        public Parameters(string appName, string appType, string appLocation)
        {
            this.appName = new AppName(appName);
            this.appType = new AppType(appType);
            this.appLocation = new AppLocation(appLocation);
        }
    }
}
