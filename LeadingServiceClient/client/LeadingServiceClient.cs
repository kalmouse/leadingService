using System;
using Grpc.Core;
using Leading.Services;

namespace Leading.Services.Client
{
    public class LeadingServiceClient
    {
        public static WarehouseService.WarehouseServiceClient getWarehouseServiceClient()
        {
            // TODO: make these channels DNS-disco-friendly
            Channel channel = new Channel(Config.getConfig("LeadingServiceClient.dll", "leadingServiceUrl"), ChannelCredentials.Insecure);
            return new WarehouseService.WarehouseServiceClient(channel);
       }

        public static RegionService.RegionServiceClient getRegionServiceClient()
        {
            // TODO: make these channels DNS-disco-friendly
            Channel channel = new Channel(Config.getConfig("LeadingServiceClient.dll", "leadingServiceUrl"), ChannelCredentials.Insecure);
            return new RegionService.RegionServiceClient(channel);
        }
    }
}
