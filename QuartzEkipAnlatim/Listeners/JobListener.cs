using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Listeners
{
    public class JobListener : IJobListener
    {
        public string Name => throw new NotImplementedException();

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
