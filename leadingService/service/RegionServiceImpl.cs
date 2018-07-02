using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Grpc.Core;
using Leading.Services;

namespace Leading.Services {

    public class RegionServiceImpl : RegionService.RegionServiceBase
    {
        private RegionRepository regionRepository;
        private AddressRepository addressRepository;

        private ILogger logger;

        public RegionServiceImpl(RegionRepository regionRepository,
            AddressRepository addressRepository,
            ILogger<RegionServiceImpl> logger)
        {
            this.regionRepository = regionRepository;
            this.addressRepository = addressRepository;
            this.logger = logger;
        }

        public override Task<Address> CreateAddress(Address request, ServerCallContext context)
        {
            return base.CreateAddress(request, context);
        }

        public override Task<FindAllRegionsResponse> FindAllRegions(FindAllRegionsRequest request, ServerCallContext context)
        {
            return base.FindAllRegions(request, context);
        }

        public override Task<FindRegionsByLevelResponse> FindRegionsByLevel(FindRegionsByLevelRequest request, ServerCallContext context)
        {
            return base.FindRegionsByLevel(request, context);
        }

        public override Task<RemoveAddressResponse> RemoveAddress(RemoveAddressRequest request, ServerCallContext context)
        {
            return base.RemoveAddress(request, context);
        }

        public override Task<Address> UpdateAddress(Address request, ServerCallContext context)
        {
            return base.UpdateAddress(request, context);
        }

        public override Task<FindRegionsBySkuIdResponse> FindRegionsBySkuId(FindRegionsBySkuIdRequest request, ServerCallContext context)
        {
            RegionRepositoryImpl regionRepositoryImpl = new RegionRepositoryImpl();
            return Task.FromResult(regionRepositoryImpl.FindRegionsBySkuId(request.SkuId));
        }
    }
}