using BidCalculationTool.Domain.Enums;

namespace BidCalculationTool.Tests.Mock.Object {
    [ExcludeFromCodeCoverage]
    public class VehicleMock : Faker<Vehicle> {
        private readonly Faker<Vehicle> fakerValidVehicleMock = new Faker<Vehicle>("en_US")
            .StrictMode(false)
            .Rules((faker, obj) => {
                obj.BasePrice = faker.Random.Decimal(100, 100000);
                obj.Id = faker.Random.Int(min:1);
                obj.IdType = (int)faker.PickRandom<EnumVehicleType>();
            });

        public Vehicle VehicleValidMock { get { return fakerValidVehicleMock; } }
        public IEnumerable<Vehicle> VehicleListValidMock(int number) => fakerValidVehicleMock.Generate(number);
    }
}
