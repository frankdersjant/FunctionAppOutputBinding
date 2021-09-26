using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppOutputBinding
{
    public static class OutputBindingDemo
    {
        [Function("OutputBindingDemo")]
        [QueueOutput("ordersprocessed")]
        public static string Run([QueueTrigger("qdemo", Connection = "")] string orderItem,
           FunctionContext context)
        {

            var logger = context.GetLogger("AzFunctionSaveToQueue");
            logger.LogInformation($" Queue qdemo trigger function processed: {orderItem}");

            return "orderitem : " + orderItem + " processed at " + DateTime.Now;
        }

     
    }
}
