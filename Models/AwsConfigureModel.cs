using Amazon;

namespace EmailProcessor.Models;

public class AwsConfigureModel
{
    public string? Key { get; set; }
    public string? Pass { get; set; }
    public string? Email { get; set; }
    public RegionEndpoint? RegionEndpoint { get; set; } = RegionEndpoint.APSouth1;
    public List<string> ReplyToAddress { get; set; }
}