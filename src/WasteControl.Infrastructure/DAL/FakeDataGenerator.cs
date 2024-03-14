using FizzWare.NBuilder;
using WasteControl.Core.Entities;
using WasteControl.Core.Enums;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Infrastructure.DAL
{
    public static class FakeDataGenerator
    {
        private static List<User> _users = null;
        private static List<ReceivingCompany> _receivingCompanies = null;
        private static List<TransportCompany> _transportCompanies = null;
        private static List<Waste> _wastes = null;
        private static List<WasteExport> _wasteExports = null;
        
        public static List<User> GenerateUsers()
        {
            if (_users == null)
            {
                _users = Builder<User>
                .CreateListOfSize(30)
                .All()
                .WithFactory(() => new User(
                    new UserName(Faker.Name.FullName()),
                    new Login(Faker.Internet.Email()),
                    new Email(Faker.Internet.Email()),
                    new Password(Faker.Name.FullName())
                ))
                .Build()
                .ToList();
            }

            return _users;
        }

        public static List<Waste> GenerateWastes()
        {
            if (_wastes == null)
            {
                User user = GenerateUsers().First();

                _wastes = Builder<Waste>
                .CreateListOfSize(60)
                .All()
                .WithFactory(() => new Waste(
                    new WasteCode(RandomCode()),
                    new WasteName(Faker.Company.Name()),
                    new WasteQuantity(Faker.RandomNumber.Next(10, 100)),
                    new WasteUnit("kg")
                ))
                .Do(w => w.ChangeCreateDate(new TimeStamp(DateTime.Now)))
                .Do(w => w.ChangeCreatedBy(user))
                .Build()
                .ToList();
            }

            return _wastes;
        }

        public static List<ReceivingCompany> GenerateReceivingCompanies()
        {
            if (_receivingCompanies == null)
            {
                User user = GenerateUsers().First();

                _receivingCompanies = Builder<ReceivingCompany>
                .CreateListOfSize(20)
                .All()
                .WithFactory(() => new ReceivingCompany(
                    new CompanyCode(RandomCode()),
                    new CompanyName(Faker.Company.Name()),
                    new Address(Faker.Address.StreetAddress()),
                    new City(Faker.Address.City()),
                    new PostalCode(RandomPostalCode()),
                    new Country(Faker.Address.Country()),
                    new Phone(RandomPhoneNumber()),
                    new Email(Faker.Internet.Email())
                ))
                .Do(c => c.ChangeCreateDate(new TimeStamp(DateTime.Now)))
                .Do(c => c.ChangeCreatedBy(user))
                .Build()
                .ToList();
            }

            return _receivingCompanies;
        }

        public static List<TransportCompany> GenerateTransportCompanies()
        {
            if (_transportCompanies == null)
            {
                User user = GenerateUsers().First();

                _transportCompanies = Builder<TransportCompany>
                .CreateListOfSize(20)
                .All()
                .WithFactory(() => new TransportCompany(
                    new CompanyCode(RandomCode()),
                    new CompanyName(Faker.Company.Name()),
                    new Address(Faker.Address.StreetAddress()),
                    new City(Faker.Address.City()),
                    new PostalCode(RandomPostalCode()),
                    new Country(Faker.Address.Country()),
                    new Phone(RandomPhoneNumber()),
                    new Email(Faker.Internet.Email())
                ))
                .Do(c => c.ChangeCreateDate(new TimeStamp(DateTime.Now)))
                .Do(c => c.ChangeCreatedBy(user))
                .Build()
                .ToList();
            }

            return _transportCompanies;
        }

        public static List<WasteExport> GenerateWasteExports()
        {
            if (_wasteExports == null)
            {
                User user = GenerateUsers().First();
                ReceivingCompany receivingCompany = GenerateReceivingCompanies().First();
                TransportCompany transportCompany = GenerateTransportCompanies().First();

                _wasteExports = Builder<WasteExport>
                .CreateListOfSize(20)
                .All()
                .WithFactory(() => new WasteExport(
                    receivingCompany,
                    transportCompany,
                    DateTime.Now.AddDays(Faker.RandomNumber.Next(1, 30)),
                    new WasteExportDescription(Faker.Lorem.Sentence()),
                    WasteExportStatus.Waiting
                ))
                .Do(w => w.ChangeCreateDate(new TimeStamp(DateTime.Now)))
                .Do(w => w.ChangeCreatedBy(user))
                .Build()
                .ToList();
            }

            return _wasteExports;
        }

        private static string RandomCode()
            => $"CODE-{Faker.RandomNumber.Next(1, 999).ToString("D4")}";

        private static string RandomPhoneNumber()
            => $"+48{Faker.RandomNumber.Next(600000000, 999999999)}";

        private static string RandomPostalCode()
            => $"{Faker.RandomNumber.Next(10, 99).ToString("D2")}-{Faker.RandomNumber.Next(100, 999).ToString("D3")}";
    }
}