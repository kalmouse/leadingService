using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leading.Services;
using Leading.Services.Client;

namespace Leading.Services.Tests
{
    [TestClass]
    public class LeadingServiceTest
    {
        [TestMethod]
        public void test_CreateAddress()
        {
            AddressDto addressDto = new AddressDto
            {
                ProvinceCode = "0001",
                ProvinceName = "Beijing",
                CityCode = "000001",
                CityName = "Beijing",
                DistrictCode = "0000001",
                DistrictName = "北京"
            };
            ObjectId addressId = LeadingServiceClient.getRegionServiceClient().CreateAddress(addressDto);
        }
    }
}
