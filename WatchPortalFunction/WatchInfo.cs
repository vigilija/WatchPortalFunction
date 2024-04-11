using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace WatchPortalFunction
{
    public class WatchInfo
    {
        private readonly ILogger<WatchInfo> _logger;

        public WatchInfo(ILogger<WatchInfo> logger)
        {
            _logger = logger;
        }

        [Function("WatchInfo")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            // return new OkObjectResult("Welcome to Azure Functions!");
            string model = req.Query["model"];

            if (model == null)
            {
                dynamic watchinfo = new { Manufacturer = "abc", CaseType = "Solid", Bazel = "Titanium", Dial = "Roman", CaseFinish = "Silver", Jewels = 15 };
                return (ActionResult)new ObjectResult($"Watch Details: {watchinfo.Manufacturer}, {watchinfo.CaseType}, {watchinfo.Bazel}, {watchinfo.Dial}, {watchinfo.CaseFinish}, {watchinfo.Jewels}");
            }
            return new BadRequestObjectResult("Please provide a watch model in the query string");
        }
    }
}
