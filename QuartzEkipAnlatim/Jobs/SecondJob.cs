using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Jobs
{
    public class SecondJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string username = dataMap.GetString("username");
            int password = dataMap.GetInt("plaka");

            var message = $"Username : {username} and Plaka {password}";
            Debug.WriteLine(message);
        }
    }
}
