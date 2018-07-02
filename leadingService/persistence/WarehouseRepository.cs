using System;
using System.Collections.Generic;

public interface WarehouseRepository {
	int CreateBranchWarehouse(ref int branchId, ref string branchRank, ref int warehouseId, ref int isAvailable);
	void DeleteBranchWarehouse(ref int branchId, ref int warehouseId);
	void UpdateBranchRankForWarehouse(ref int branchId, ref string branchRank, ref int warehouseId);
	List<Warehouse> FindWarehouses(ref int branchId);
	List<Warehouse> FindWarehouses(ref int branchId, ref int warehouseType);
	void CreateWarehouseSku(ref int skuId, ref int warehouseId);
	void DeleteWarehouseSku(ref int skuId, ref int warehouseId);
	int[] FindWarehouseSkuIds(ref int warehouseId, ref int isAvailable);
	Warehouse GetWarehouseById(ref int warehouseId);
	void CreateWarehouseManager(ref int managerId, ref int warehouseId);
	void DeleteWarehouseManager(ref int managerId, ref int warehouseId);
	BranchPricePolicy CreateBranchPricePolicy(ref BranchPricePolicy branchPricePolicy);
	void UpdateBranchPricePolicy(ref BranchPricePolicy branchPricePolicy);
	BranchPricePolicy GetBranchPricePolicy(ref int branchId, ref int warehouseId, ref int type, ref int relatedId);
	List<BranchPricePolicy> FindBranchPricePolicies(ref int branchId, ref int warehouseId);
	void DeleteBranchPricePolicy(ref int branchPricePolicyId);

}
