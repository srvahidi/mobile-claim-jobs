using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Configurations
{
    public class EnvironmentConfiguration : IEnvironmentConfiguration
    {
        public EnvironmentConfiguration(IConfiguration configuration)
        {
            var vcap = configuration["VCAP_SERVICES"];
            if (vcap == null)
            {
                return;
            }

            var jVcap = JObject.Parse(vcap);
            var jServices = jVcap.Properties().Where(p => p.Value.Type == JTokenType.Array).SelectMany(p => (JArray)p.Value).ToArray();

            MBEWrapperUrl = new Uri(jServices.First(s => s["name"].Value<string>() == "mbe-config")["credentials"]["MBE_WRAPPER_URL"].Value<string>());
            MBEMongoDbUrl = jServices.First(s => s["name"].Value<string>() == "mbe-config")["credentials"]["MBE_DB_URL"].Value<string>();
            MBEDbName = jServices.First(s => s["name"].Value<string>() == "mbe-config")["credentials"]["MBE_DB_NAME"].Value<string>();
            DaystoQueryFrom = Int32.Parse(jServices.First(s => s["name"].Value<string>() == "mbe-config")["credentials"]["RETRO_DAYS"].Value<string>());
            HoursToWaitBeforeUpdate = Int32.Parse(jServices.First(s => s["name"].Value<string>() == "mbe-config")["credentials"]["HOURS_TO_WAIT_BEFORE_UPDATE"].Value<string>());
            JobRunFrequency = Int32.Parse(jServices.First(s => s["name"].Value<string>() == "mbe-config")["credentials"]["JOB_RUN_FREQUENCY"].Value<string>());
        }
        public Uri MBEWrapperUrl { get; }
        public string MBEMongoDbUrl { get; }
        public string MBEDbName { get; }
        public int DaystoQueryFrom { get; }
        public int HoursToWaitBeforeUpdate { get; }
        public int JobRunFrequency { get; }
    }
}
