using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace VogCodeChallenge.AWSLambda
{
    public class Function
    {
        public void FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
        {
            try
            {
                context.Logger.LogLine($"Beginning to process records...");

                foreach (var record in dynamoEvent.Records)
                {
                    context.Logger.LogLine($"Event ID: {record.EventID}");
                    context.Logger.LogLine($"Event Name: {record.EventName}");
                    context.Logger.LogLine($"Event Source: {record.EventSource}");
                    context.Logger.LogLine($"Event Source Arn: {record.EventSourceArn}");
                    context.Logger.LogLine($"User Identity: {record}");
                }

                context.Logger.LogLine("Stream processing complete.");
            }
            catch (NullReferenceException)
            {
                context.Logger.LogLine("Error whille accessing a property");
            }
            catch
            {
                context.Logger.LogLine("Somwthing went wrong please try Again");
            }
        }
    }
}