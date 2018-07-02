using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Grpc.Core;
using Leading.Services;
using System.Data;
using System.Data.SqlClient;

namespace Leading.Services {

    public class WarehouseServiceImpl : WarehouseService.WarehouseServiceBase
    {
        private WarehouseRepository repository;

        private ILogger logger;

        public WarehouseServiceImpl(WarehouseRepository repository,
            ILogger<WarehouseServiceImpl> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public override async Task<AddBranchToWarehouseResponse> AddBranchToWarehouseAsync(IAsyncStreamReader<AddBranchToWarehouseRequest> requestStream, ServerCallContext context)
        {
            AddBranchToWarehouseResponse addBranchToWarehouseResponse = new AddBranchToWarehouseResponse();
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                WarehouseRepositoryImpl warehouseRepositoryImpl = new WarehouseRepositoryImpl();
                int branchId = requestStream.Current.BranchId;
                string branchRank = requestStream.Current.BranchRank;
                int warehouseId = requestStream.Current.WarehouseId;
                int isAvailable = requestStream.Current.IsAvailable;
                int result = warehouseRepositoryImpl.CreateBranchWarehouse(ref branchId, ref branchRank, ref warehouseId, ref isAvailable);
                addBranchToWarehouseResponse.IsOk = result > 0 ? true : false;
            }
            return addBranchToWarehouseResponse;
        }


        //public override Task<AddBranchToWarehouseResponse> AddBranchToWarehouse(AddBranchToWarehouseRequest request, ServerCallContext context)
        //{
        //   return Task.Run(() =>
        //    {
        //        WarehouseRepositoryImpl warehouseRepositoryImpl = new WarehouseRepositoryImpl();
        //        int branchId = request.BranchId;
        //        string branchRank = request.BranchRank;
        //        int warehouseId = request.WarehouseId;
        //        int warehouseType = request.WarehouseType;
        //        int result= warehouseRepositoryImpl.CreateBranchWarehouse(ref branchId, ref branchRank, ref warehouseId, ref warehouseType);
        //        AddBranchToWarehouseResponse addBranchToWarehouseResponse = new AddBranchToWarehouseResponse();
        //        addBranchToWarehouseResponse.IsOk = result > 0 ? true : false;
        //        return addBranchToWarehouseResponse;
        //    });
        //}
    }
}