namespace BidCalculationTool.Tests.Presentation {
        public class VehicleControllerTests {
        private VehicleController _vehicleController;
        private readonly VehicleMock _vehicleMock;
        private readonly VehicleServiceMock _vehicleServiceMock;

        public VehicleControllerTests() {
            _vehicleServiceMock = new VehicleServiceMock();
            _vehicleMock = new VehicleMock();
            _vehicleController = new VehicleController(_vehicleServiceMock.Object);
        }

        [Fact]
        public async Task CalculateTotalCost_ShouldReturnOkResult_WithTotalCost() {
            // Arrange
            var vehicle = _vehicleMock.VehicleValidMock;
            var vehicleDto = MapperMock.mockMapper.Map<VehicleDto>(vehicle);

            _vehicleServiceMock.MockCalculateTotalCost(vehicleDto, 1000.00m);

            // Act
            var result = await _vehicleController.CalculateTotalCost(vehicleDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

        }

        [Fact]
        public async Task CalculateTotalCost_ShouldReturnBadRequest_WhenArgumentNullExceptionThrown() {
            // Arrange
            var vehicle = _vehicleMock.VehicleValidMock;
            var vehicleDto = MapperMock.mockMapper.Map<VehicleDto>(vehicle);

            var exceptionMessage = "VehicleDto is null";
            _vehicleServiceMock.Setup(service => service.CalculateTotalCost(It.IsAny<VehicleDto>()))
                .Callback(() => throw new ArgumentNullException(nameof(vehicleDto), exceptionMessage))
                .Returns(Task.FromResult(0m));

            // Act
            var result = await _vehicleController.CalculateTotalCost(vehicleDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal($"Error: {exceptionMessage} (Parameter 'vehicleDto')", result.Value);
        }

        [Fact]
        public async Task CalculateTotalCost_ShouldReturnInternalServerError_WhenExceptionThrown() {
            // Arrange
            var vehicle = _vehicleMock.VehicleValidMock;
            var vehicleDto = MapperMock.mockMapper.Map<VehicleDto>(vehicle);

            var exceptionMessage = "Unexpected error";
            _vehicleServiceMock.Setup(service => service.CalculateTotalCost(It.IsAny<VehicleDto>()))
                .Callback(() => throw new Exception(exceptionMessage))
                .Returns(Task.FromResult(0m));

            // Act
            var result = await _vehicleController.CalculateTotalCost(vehicleDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
