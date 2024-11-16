using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Jobs
{
    public class fourJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.MergedJobDataMap;
            string triggerparam = dataMap.GetString("triggerparam");
            var message = $"Ekip lideri {triggerparam}";
            Debug.WriteLine(message);
        }
    }
}
