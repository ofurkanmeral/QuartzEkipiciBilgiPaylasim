using Quartz;
using QuartzEkipAnlatim.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Jobs
{
    public class ThirdJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                string username = dataMap.GetString("username");
                Developer ahmet = (Developer)dataMap.Get("developer");
                var message = $"Ekip lideri {ahmet.FullName} sicili ise {ahmet.SicilNo}";
                Debug.WriteLine(message);
            }
            catch (Exception ex)
            {
                //bir işin bir hata nedeniyle başarısız olması durumunda, işin hemen tekrar
                //çalıştırılması ve hatanın düzeltilmesi için bir şans verilmesi gerekebilir. 
                throw new JobExecutionException(ex, refireImmediately: true)
                {
                    UnscheduleFiringTrigger = true,
                    UnscheduleAllTriggers = true
                };
            }

        }
    }
}
