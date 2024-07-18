namespace BidCalculationTool.Infrastructure.Repository {
    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository {
        public VehicleTypeRepository(ILogger<Repository<VehicleType>> logger) : base(logger) { }
    }
}
