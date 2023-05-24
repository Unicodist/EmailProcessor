using Amazon.SimpleEmail.Model;

namespace EmailProcessor.Models;

public class AwsEmailModel
{
    public string Data { get; set; }
    public List<string> Destinations { get; set; }
    public string Subject { get; set; }
}