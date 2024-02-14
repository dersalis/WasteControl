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

        public Company(CompanyCode code, CompanyName name, Address address, City city, PostalCode postalCode, Country country, Phone phone, Email email)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Email = email;
            IsActive = true;
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