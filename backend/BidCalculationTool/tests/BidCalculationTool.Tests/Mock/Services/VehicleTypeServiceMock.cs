namespace BidCalculationTool.Tests.Mock.Services {
    public class VehicleTypeServiceMock : Mock<IVehicleTypeService> {
        public VehicleTypeServiceMock MockGetAll(IEnumerable<VehicleType> result) {
            Setup(service => service.GetAll())
                .Returns(result);
            return this;
        }
    }
}
