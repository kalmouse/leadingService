
using System;
public interface AddressRepository {
    Address CreateAddress(Address address);
    Address UpdateAddress(Address address);
    void DeleteAddress(int id);
}
