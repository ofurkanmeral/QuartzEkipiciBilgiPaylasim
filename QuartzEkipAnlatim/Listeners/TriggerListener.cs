﻿using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Listeners
{
    public class TriggerListener : ITriggerListener
    {
        public string Name => throw new NotImplementedException();

        public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
