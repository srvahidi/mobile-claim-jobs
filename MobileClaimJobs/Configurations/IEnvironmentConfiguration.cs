using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Configurations
{
    public interface IEnvironmentConfiguration
    {
        Uri MBEWrapperUrl { get; }
        string MBEMongoDbUrl { get; }
        string MBEDbName { get; }
        int DaystoQueryFrom { get; }
        int HoursToWaitBeforeUpdate { get; }
        int JobRunFrequency { get; }
    }
}
