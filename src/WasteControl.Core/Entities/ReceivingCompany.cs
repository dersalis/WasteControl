using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class ReceivingCompany : Company
    {
        public ReceivingCompany(CompanyCode code, CompanyName name, Address address, City city, PostalCode postalCode, Country country, Phone phone, Email email)
         : base(code, name, address, city, postalCode, country, phone, email)
        {
        }
    }
}