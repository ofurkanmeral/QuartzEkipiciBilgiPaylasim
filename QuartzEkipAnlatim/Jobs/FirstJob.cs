using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Jobs
{
    public class FirstJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Debug.WriteLine($"FirstJob Execute Success {DateTime.Now}");
        }
    }
}
