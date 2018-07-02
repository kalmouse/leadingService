using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using leadingService;

public class AddressRepositoryImpl : AddressRepository
{
    private IDbConnection db = new SqlConnection(Program.Configuration.GetConnectionString("LeadingDB"));

    public Address CreateAddress(Address address)
    {
        throw new NotImplementedException();
    }

    public void DeleteAddress(int id)
    {
        throw new NotImplementedException();
    }

    public Address UpdateAddress(Address address)
    {
        throw new NotImplementedException();
    }
}
