namespace BidCalculationTool.Tests.Mock.Object {
    [ExcludeFromCodeCoverage]
    public class VehicleTypeMock : Faker<VehicleType> {
        private readonly Faker<VehicleType> fakerValidVehicleTypeMock = new Faker<VehicleType>("en_US")
            .StrictMode(false)
            .Rules((faker, obj) => {
                obj.Id = (int)faker.PickRandom<EnumVehicleType>();
                obj.Name = faker.PickRandom<EnumVehicleType>().ToString();
            });

        public VehicleType VehicleTypeValidMock { get { return fakerValidVehicleTypeMock; } }
        public IEnumerable<VehicleType> VehicleTypeListValidMock(int number) => fakerValidVehicleTypeMock.Generate(number);
    }
}
