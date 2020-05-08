using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MobileClaimJobs.Interfaces;
using MobileClaimJobs.Outside;
using MobileClaimJobs.Persistence;
using MobileClaimJobs.Repositories;
using MobileClaimJobs.ScheduledJobs;
using Quartz;
using Quartz.Impl;

namespace MobileClaimJobs
{
    public static class JobsInit
    {
        public static async Task InitiateJobs()
        {
            var services = new ServiceCollection();
            services.AddScoped<ClaimsJob>();
            services.AddScoped<MBEDBContext>();
            services.AddScoped<IMBERepository, MBERepository>();
            services.AddScoped<IMongoConnection, MongoConnection>();
            services.AddHttpClient<IHttpPort, HttpAdapter>();

            var serviceProvider = services.BuildServiceProvider();

            var props = new NameValueCollection
            {
                {"quartz.serializer.type", "binary"}
            };
            var factory = new StdSchedulerFactory(props);
            IScheduler scheduler = await factory.GetScheduler();
            scheduler.JobFactory = new ClaimsJobFactory(serviceProvider);

            await scheduler.Start();
            IJobDetail claimsJob = JobBuilder.Create<ClaimsJob>()
                .WithIdentity("Claims", "Processing")
                .Build();
            ITrigger claimsJobTrigger = TriggerBuilder.Create()
                .WithIdentity("Claims", "Processing")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(Int32.Parse(Environment.GetEnvironmentVariable("JOB_RUN_FREQUENCY")))
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(claimsJob, claimsJobTrigger);
        }

    }
}



