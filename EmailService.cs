using Amazon;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

using EmailProcessor.Helpers;
using EmailProcessor.Models;

using Serilog;

namespace EmailProcessor;

public class EmailService
{
    public static AwsConfigureModel? Model;

    public EmailService()
    {
    }

    public virtual async Task<int> SendEmailAsync(AwsEmailModel model)
    {
        if (!Check.ValidateAwsConfigureModel(Model))
        {
            throw new InvalidOperationException("Aws email is not configured");
        }

        BasicAWSCredentials credentials = new(Model!.Key, Model.Pass);
        using var client = new AmazonSimpleEmailServiceClient(credentials, Model.RegionEndpoint);
        var body = new Body()
        {
            Html = new Content()
            {
                Charset = "UTF-8",
                Data = model.Data,
            }
        };
        var destinations = new Destination() { ToAddresses = model.Destinations };
        var message = new Message() { Subject = new Content(model.Subject), Body = body };
        var sendRequest = new SendEmailRequest()
        {
            Source = Model.Email,
            Destination = destinations,
            Message = message,
            ReplyToAddresses = Model.ReplyToAddress
        };

        try
        {
            await client.SendEmailAsync(sendRequest);
            return model.Destinations.Count;
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            throw;
        }
    }
}