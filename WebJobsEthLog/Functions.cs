//using Microsoft.Azure.WebJobs;
//using Microsoft.Extensions.Logging;

//namespace WebJobsEthLog;

//public class Functions
//{
//    public async Task TimerTriggerOperation([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo timerInfo, ILogger logger, CancellationToken cancellationToken)
//    {
//        logger.LogInformation("Test binn!!");
//    }

//    //public static void ProcessQueueMessage([QueueTrigger("queue")] string message, ILogger logger)
//    //{
//    //    logger.LogInformation(message);
//    //}
//}
