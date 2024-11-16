using Microsoft.AspNetCore.Mvc;
using Quartz;
using QuartzEkipAnlatim.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzEkipAnlatim.Controllers
{
    public class HomeController : Controller
    {
        IScheduler _schedule;
        public HomeController(IScheduler schedule)
        {
            _schedule = schedule;
        }
        public async Task<IActionResult> Index()
        {

            //FİRST
            //var job=JobBuilder.Create<FirstJob>()
            //    .WithIdentity("firstjob", "example")
            //    .Build();

            //ITrigger trigger=TriggerBuilder.Create()
            //    .WithIdentity("firstTrigger","exampleg")
            //    .StartNow()
            //    .WithSimpleSchedule(x=>x.WithIntervalInSeconds(1).RepeatForever())
            //    .Build();

            //await _schedule.ScheduleJob(job, trigger);


            //SECOND
            //IJobDetail job=JobBuilder.Create<SecondJob>()
            //    .UsingJobData("username","tarikzengin")
            //    .UsingJobData("plaka",22)
            //    .WithIdentity(nameof(SecondJob),"second")
            //    .Build();

            //ITrigger trigger=TriggerBuilder.Create()
            //    .WithIdentity("secondTrigger","second")
            //    .StartNow()
            //    .WithSimpleSchedule(x=>x.WithIntervalInSeconds(2).RepeatForever())
            //    .Build();

            //await _schedule.ScheduleJob(job, trigger);


            //THİRD
            //IJobDetail job=JobBuilder.Create<ThirdJob>()
            //    .WithIdentity(nameof(ThirdJob),"third")
            //    .Build();
            //job.JobDataMap.Put("developer", new Developer { FullName = "Ahmet Culfa", SicilNo = 13969 });

            //ITrigger trigger=TriggerBuilder.Create()
            //    .WithIdentity("trigger","sadasd")
            //    .StartNow()
            //    .WithSimpleSchedule(x=>x.WithIntervalInSeconds(1).RepeatForever())
            //    .Build();
            //await _schedule.ScheduleJob(job, trigger);

            //Four

            //IJobDetail job = JobBuilder.Create<fourJob>()
            //    .WithIdentity(nameof(fourJob), "third")
            //    .Build();
            //job.JobDataMap.Put("developer", new Developer { FullName = "Ahmet Culfa", SicilNo = 13969 });

            //ITrigger trigger = TriggerBuilder.Create()
            //    .UsingJobData("triggerparam","Triggerdan bir haber mi var")
            //    .WithIdentity("trigger", "sadasd")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x.WithIntervalInSeconds(1).RepeatForever())
            //    .Build();
            //await _schedule.ScheduleJob(job, trigger);

            IJobDetail job = JobBuilder.Create<fourJob>()
                //.UsingJobData("triggerparam","OnurFurkanMeral")
                .WithIdentity("testd", "test")
                .StoreDurably()
                .Build();

            await _schedule.AddJob(job, true);

            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(job)
                .UsingJobData("triggerparam", "OnurFurkanMeral")
                .WithIdentity("TriggerMercedes", "TriggerMercedesGroup")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            ITrigger trigger2 = TriggerBuilder.Create()
                .ForJob(job)
                .UsingJobData("triggerparam", "HazarAnıl")
                .WithIdentity("TriggerJeep", "TriggerJeepGroup")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            ITrigger trigger3 = TriggerBuilder.Create()
                .ForJob(job)
                .UsingJobData("triggerparam", "HazarAnıl")
                .WithIdentity("test3", "test")
                .StartNow()
                .WithDailyTimeIntervalSchedule(
                    x => x.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(20, 30))
                        .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 00))
                        .OnDaysOfTheWeek(DayOfWeek.Monday, DayOfWeek.Friday, DayOfWeek.Sunday)
                        .WithIntervalInMinutes(5))
                .Build();

            ITrigger trigger4 = TriggerBuilder.Create()
                .ForJob(job)
                .UsingJobData("triggerparam", "HazarAnıl")
                .WithIdentity("test4", "test")
                .StartNow()
                .WithCalendarIntervalSchedule(
                    x => x.WithIntervalInYears(1)
                    .PreserveHourOfDayAcrossDaylightSavings(true)//Yaz saati uygulaması
                    .SkipDayIfHourDoesNotExist(true))//Yaz saati uygulanırken 2:30 mesela 3:30 çekildi bi anda  arada 3 de çalışacak job kaçmasın diye
                .Build();

            await _schedule.ScheduleJob(trigger);
            await _schedule.ScheduleJob(trigger2);


            return View();

       
        }
    }
}
