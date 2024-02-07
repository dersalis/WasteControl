using FizzWare.NBuilder;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.DAL.Repositories.InMemory
{
    public class InMemoryWasteRepository : IRepository<Waste>
    {
        private readonly List<Waste> _wastes;

        public InMemoryWasteRepository()
        {
            // _wastes = new List<Waste>();
            _wastes = GenerateData();
        }

        public Task AddAsync(Waste entity)
        {
            _wastes.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _wastes.RemoveAll(w => w.Id == (ID)id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Waste>> GetAllAsync()
            => Task.FromResult(_wastes.AsEnumerable());

        public Task<Waste> GetAsync(Guid id)
            => Task.FromResult(_wastes.FirstOrDefault(w => w.Id == (ID)id));

        public Task UpdateAsync(Waste entity)
            => Task.CompletedTask;


        private List<Waste> GenerateData()
        {

            List<Waste> wastes = Builder<Waste>
                .CreateListOfSize(20)
                .All()
                .WithFactory(() => new Waste(
                    new WasteCode($"CODE-{Faker.RandomNumber.Next(1, 999).ToString("D4")}"),
                    new WasteName(Faker.Company.Name()),
                    new WasteQuantity(Faker.RandomNumber.Next(10, 100)),
                    new WasteUnit("kg")
                ))
                .Do(w => w.ChangeCreateDate(new TimeStamp(DateTime.Now)))
                .Build()
                .ToList();


            return wastes;
        }
    }
}