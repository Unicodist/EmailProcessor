using Amazon;

using EmailProcessor.Models;

using Xunit;

namespace EmailProcessor.Tests;

public class EmailTests
{
    private AwsConfigureModel model = new()
    {
        RegionEndpoint = RegionEndpoint.APSouth1,
        Email = "identity@premiumtech.com.np",
        Key = "AKIAX5HIY3IRJERMGGVG",
        Pass = "PlWDkX0ZA7nNpfQ1uuwJVPluPzcU0AFsdbBQKhDI",
        ReplyToAddress = new List<string>() {"ashishneupane999@gmail.com"}
    };

    [Fact]
    public async Task SendEmailTest()
    {

        var emailService = new EmailService();
        EmailService.Model = model;

        var emailModel = new AwsEmailModel()
        {
            Data = "K chha Gaurav sir! kaam kati sakiyo ta??",
            Destinations = new List<string>() { "mail.gauravnyaupane@gmail.com" },
            Subject = "Yeta yeta yeta"
        };

        await emailService.SendEmailAsync(emailModel);
    }
}