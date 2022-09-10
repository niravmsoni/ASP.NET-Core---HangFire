using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core___HangFire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangFireController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public IActionResult BackgroundJobExecution()
        {
            //Enqueues a background job
            var jobId = BackgroundJob.Enqueue(() => CW("Hello"));

            return Ok($"HangFire Job ID: {jobId}. ");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult BackGroundJobWithSchedule()
        {
            //Schedules a background job to occur after every 30 seconds
            int timeInSeconds = 30;
            var jobId = BackgroundJob.Schedule(() => CW("Hello"), TimeSpan.FromSeconds(timeInSeconds));

            return Ok($"HangFire Job ID: {jobId}. Will run in {timeInSeconds}");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CronExecution()
        {
            //Cron execution
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Update DB"), Cron.Minutely);
            return Ok("Cronned");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Scheduled()
        {
            //Schedule jobs
            int timeInSeconds = 30;
            var parentJobId = BackgroundJob.Schedule(() => Console.WriteLine("Scheduled!"), TimeSpan.FromSeconds(timeInSeconds));

            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("Will execute after first Background job is complete"));

            return Ok("Scheduled and waiting!");
        }


        public void CW(string text)
        {
            Console.WriteLine(text);
        }
    }
}