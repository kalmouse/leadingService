using System;

namespace Leading.Services.model
{
    public class Address
    {
        public int Id { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactName { get; set; }
        public string CodeType { get; set; }
    }
}
