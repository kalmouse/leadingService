using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class WarehouseRepositoryImpl : WarehouseRepository {
    public void DeleteBranchPricePolicy(ref int branchPricePolicyId) {




        throw new System.Exception("Not implemented");
    }
    public List<BranchPricePolicy> FindBranchPricePolicies(ref int branchId, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public BranchPricePolicy GetBranchPricePolicy(ref int branchId, ref int warehouseId, ref int type, ref int relatedId) {
        throw new System.Exception("Not implemented");
    }
    public void UpdateBranchPricePolicy(ref BranchPricePolicy branchPricePolicy) {
        throw new System.Exception("Not implemented");
    }
    public BranchPricePolicy CreateBranchPricePolicy(ref BranchPricePolicy branchPricePolicy) {
        throw new System.Exception("Not implemented");
    }
    public void DeleteWarehouseManager(ref int managerId, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public void CreateWarehouseManager(ref int managerId, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public Warehouse GetWarehouseById(ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public int[] FindWarehouseSkuIds(ref int warehouseId, ref int isAvailable) {
        throw new System.Exception("Not implemented");
    }
    public void DeleteWarehouseSku(ref int skuId, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public void CreateWarehouseSku(ref int skuId, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public List<Warehouse> FindWarehouses(ref int branchId, ref int warehouseType) {
        throw new System.Exception("Not implemented");
    }
    public List<Warehouse> FindWarehouses(ref int branchId) {
        throw new System.Exception("Not implemented");
    }
    public void UpdateBranchRankForWarehouse(ref int branchId, ref string branchRank, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public void DeleteBranchWarehouse(ref int branchId, ref int warehouseId) {
        throw new System.Exception("Not implemented");
    }
    public int CreateBranchWarehouse(ref int branchId, ref string branchRank, ref int warehouseId, ref int warehouseType) {
        string connectionString = "Data Source=192.168.0.138;Initial Catalog=Leading;Persist Security Info=True;User ID=sa;Password=XS12345^";

        string sqlCommandText = @"INSERT INTO warehouse_branch(warehouse_id,branch_id,rank,is_available,add_time,update_time)VALUES(@warehouse_id,@branch_id,@rank,@is_vailable,@add_time,@update_time)";
        using (IDbConnection conn = new SqlConnection(connectionString))
        {
            DynamicParameters pars = new DynamicParameters();
            pars.Add("warehouse_id", warehouseId,System.Data.DbType.Int32);
            pars.Add("branch_id", branchId, System.Data.DbType.Int32);
            pars.Add("rank", branchRank, System.Data.DbType.String);
            pars.Add("is_vailable", 1, System.Data.DbType.Int32);
            pars.Add("add_time", DateTime.Now, System.Data.DbType.DateTime);
            pars.Add("update_time", DateTime.Now, System.Data.DbType.DateTime);
            return conn.Execute(sqlCommandText, pars);
        }
    }

}
