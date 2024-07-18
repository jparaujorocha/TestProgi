
namespace BidCalculationTool.Services.Interface {
    public interface IVehicleService {
        Task<decimal> CalculateTotalCost(VehicleDto vehicle);
    }
}
