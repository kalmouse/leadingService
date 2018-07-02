using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

public class RegionRepositoryImpl : RegionRepository  {
    public List<Region> FindRegionsBySkuId(int sku_id)
    {
        string sql = "select * from sku_region where sku_id=@sku_id";
        SqlParameter[] param = { new SqlParameter("@sku_id",SqlDbType.Int)};
        param[0].Value = sku_id;
        List<Region> list = leadingService.DapperHelper<Region>.Query(sql,param);
        return list;
    }   
}
