
namespace BidCalculationTool.Infrastructure.Repository {
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository {
        public VehicleRepository(ILogger<Repository<Vehicle>> logger) : base(logger) { }
    }
}
