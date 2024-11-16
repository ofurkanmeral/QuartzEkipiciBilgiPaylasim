using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using QuartzEkipAnlatim.Listeners;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Jobs
{
    public static class ConfigureQuartz
    {
        public static void AddQuartzDependency(this IServiceCollection services)
        {
            var quartzScheduler = ConfigureQuartzService();
            services.AddSingleton(quartzScheduler);
        }
        public static IScheduler ConfigureQuartzService()
        {
            NameValueCollection props = new NameValueCollection
             {
              { "quartz.serializer.type", "json" },
               { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                 { "quartz.jobStore.dataSource", "default" },
                 { "quartz.dataSource.default.provider", "SqlServer" },
                  { "quartz.dataSource.default.connectionString", "Server=.;Integrated Security=true;Initial Catalog = Quartzz" },
                  {"quartz.jobStore.clustered","true" },
                  { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz" }
              };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var scheduler = factory.GetScheduler().Result;
            //scheduler.ListenerManager.AddJobListener(new JobListener());
            //scheduler.ListenerManager.AddTriggerListener(new TriggerListener());
            //scheduler.ListenerManager.AddSchedulerListener(new ScheduleListener());

            scheduler.Start();
            return scheduler;
        }
    }
}
