using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class Company : BaseEntity
    {
        public CompanyCode Code { get; private set; }
        public CompanyName Name { get; private set; }
        public Address Address { get; private set; }
        public City City { get; private set; }
        public PostalCode PostalCode { get; private set; }
        public Country Country { get; private set; }
        public Phone Phone { get; private set; }
        public Email Email { get; private set; }

        public Company(string code, string name, string address, string city, string postalCode, string country, string phone, string email)
        {
            Id = Guid.NewGuid();
            Code = new CompanyCode(code);
            Name = new CompanyName(name);
            Address = new Address(address);
            City = new City(city);
            PostalCode = new PostalCode(postalCode);
            Country = new Country(country);
            Phone = new Phone(phone);
            Email = new Email(email);
        }
        
        public void ChangeCompanyCode(string code)
        {
            Code = new CompanyCode(code);
        }

        public void ChangeCompanyName(string name)
        {
            Name = new CompanyName(name);
        }

        public void ChangeAddress(string address)
        {
            Address = new Address(address);
        }

        public void ChangeCity(string city)
        {
            City = new City(city);
        }

        public void ChangePostalCode(string postalCode)
        {
            PostalCode = new PostalCode(postalCode);
        }

        public void ChangeCountry(string country)
        {
            Country = new Country(country);
        }

        public void ChangePhone(string phone)
        {
            Phone = new Phone(phone);
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

    }
}