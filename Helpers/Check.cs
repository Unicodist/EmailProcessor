using EmailProcessor.Models;

using Serilog;

namespace EmailProcessor.Helpers;

public class Check
{
    public static bool ValidateAwsConfigureModel(AwsConfigureModel? model)
    {
        if (model == null)
        {
            throw new Exception("AwsEmail is not configured");
        }
        if (model.Key == null || model.Pass == null || model.Email == null)
        {
            throw new Exception("Please provide a correct Aws Email credential");
        }

        if (model.RegionEndpoint == null)
        {
            Log.Warning("No region endpoints provided. Using AsiaSouthAp1 as default");
        }
        return true;
    }
}