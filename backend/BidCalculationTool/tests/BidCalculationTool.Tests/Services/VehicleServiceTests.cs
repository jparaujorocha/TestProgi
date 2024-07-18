
namespace BidCalculationTool.Tests.Services {

    public class VehicleServiceTests {
        private readonly VehicleService _vehicleService;
        private readonly VehicleMock _vehicleMock;
        private readonly VehicleRepositoryMock _vehicleRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<VehicleService>> _loggerMock;

        public VehicleServiceTests() {
            _vehicleRepositoryMock = new VehicleRepositoryMock();
            _vehicleMock = new VehicleMock();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<VehicleService>>();
            _vehicleService = new VehicleService(_loggerMock.Object, _mapperMock.Object, _vehicleRepositoryMock.Object);
        }

        [Theory]
        [InlineData(398, EnumVehicleType.Common, 550.76)]
        [InlineData(501, EnumVehicleType.Common, 671.02)]
        [InlineData(57, EnumVehicleType.Common, 173.14)]
        [InlineData(1800, EnumVehicleType.Luxury, 2001)]
        [InlineData(1100, EnumVehicleType.Common, 1287)]
        [InlineData(1000000, EnumVehicleType.Luxury, 1020170)]
        public async Task CalculateTotalCost_ShouldReturnExpectedResult(decimal basePrice, EnumVehicleType type, decimal expectedTotal) {
            // Arrange

            var vehicle = _vehicleMock.VehicleValidMock;
            vehicle = new Vehicle {
                Id = vehicle.Id,
                BasePrice = basePrice,
                IdType = (int)type
            };
            var vehicleDto = MapperMock.mockMapper.Map<VehicleDto>(vehicle);

            _vehicleRepositoryMock.MockAddAsync(vehicle, vehicle);

            // Act
            var result = await _vehicleService.CalculateTotalCost(vehicleDto);

            // Assert
            Assert.Equal(expectedTotal, result);
        }

        [Fact]
        public async Task CalculateTotalCost_ShouldThrowArgumentNullException_WhenVehicleDtoIsNull() {
            // Arrange
            VehicleDto vehicleDto = null!;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _vehicleService.CalculateTotalCost(vehicleDto));
        }

        [Fact]
        public async Task CalculateTotalCost_ShouldThrownsException() {
            // Arrange
            var vehicle = _vehicleMock.VehicleValidMock;
            var vehicleDto = MapperMock.mockMapper.Map<VehicleDto>(vehicle);
            var exception = new Exception("Test exception");

            _mapperMock.Setup(m => m.Map<Vehicle>(It.IsAny<VehicleDto>())).Throws(exception);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _vehicleService.CalculateTotalCost(vehicleDto));
        }
    }
}
