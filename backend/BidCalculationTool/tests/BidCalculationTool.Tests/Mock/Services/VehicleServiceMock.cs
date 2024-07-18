namespace BidCalculationTool.Tests.Mock.Services {

    public class VehicleServiceMock : Mock<IVehicleService> {
        public VehicleServiceMock MockCalculateTotalCost(VehicleDto vehicleDto, decimal result) {
            Setup(service => service.CalculateTotalCost(It.Is<VehicleDto>(vehicle => vehicle.Id == vehicleDto.Id)))
                .ReturnsAsync(result);
            return this;
        }
    }
}
