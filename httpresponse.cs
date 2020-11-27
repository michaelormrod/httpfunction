using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace ERI.Educate
{
    public static class httpresponse
    {
        [FunctionName("HelloHTML")]
        public static async Task<IActionResult> HelloHTML([HttpTrigger(AuthorizationLevel.Function, "get", Route = "hello_html")]
                                                      HttpRequest req,
                                                     ILogger log)
        {
            //return new ContentResult { Content = "<html><body>Hello <b>world</b></body></html>", ContentType = "text/html" };
            var myObj = new { name = "thomas", location = "Denver" };
            var jsonToReturn = JsonConvert.SerializeObject(myObj);

            return new ContentResult
            {

                Content = jsonToReturn,
                ContentType = "text/json",
                StatusCode = (int)HttpStatusCode.OK



            };
        }

    }
}
