namespace BidCalculationTool.Tests.Mock.Repository {
    public class VehicleRepositoryMock : Mock<IVehicleRepository> {

        public VehicleRepositoryMock MockGetAllAsync(IEnumerable<Vehicle> result) {
            Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(result);
            return this;
        }

        public VehicleRepositoryMock MockGetByIdAsync(int id, Vehicle result) {
            Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(result);
            return this;
        }

        public VehicleRepositoryMock MockAddAsync(Vehicle entity, Vehicle result) {
            Setup(repo => repo.AddAsync(It.IsAny<Vehicle>()))
                .ReturnsAsync(result);
            return this;
        }

        public VehicleRepositoryMock MockUpdateAsync() {
            Setup(repo => repo.UpdateAsync(It.IsAny<Vehicle>()))
                .Returns(Task.CompletedTask);
            return this;
        }

        public VehicleRepositoryMock MockDeleteAsync() {
            Setup(repo => repo.DeleteAsync(It.IsAny<Vehicle>()))
                .Returns(Task.CompletedTask);
            return this;
        }

        public VehicleRepositoryMock MockCommitAsync(int result) {
            Setup(repo => repo.CommitAsync())
                .ReturnsAsync(result);
            return this;
        }
    }
}
