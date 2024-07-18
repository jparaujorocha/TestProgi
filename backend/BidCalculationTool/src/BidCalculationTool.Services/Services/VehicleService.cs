namespace BidCalculationTool.Services.Services {
    public class VehicleService : IVehicleService {
        private readonly ILogger<VehicleService> _logger;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(ILogger<VehicleService> logger, IMapper mapper, IVehicleRepository vehicleRepository) {
            _logger = logger;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<decimal> CalculateTotalCost(VehicleDto vehicleDto) {
            try {
                Validate(vehicleDto);

                decimal basicFee = CalculateBasicBuyerFee(vehicleDto);
                decimal specialFee = CalculateSpecialFee(vehicleDto);
                decimal associationFee = CalculateAssociationFee(vehicleDto.BasePrice);
                decimal storageFee = 100;

                var vehicle = _mapper.Map<Vehicle>(vehicleDto);
                _ = await _vehicleRepository.AddAsync(vehicle);

                return vehicleDto.BasePrice + basicFee + specialFee + associationFee + storageFee;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error calculating total cost for vehicle with id {VehicleId}", vehicleDto?.Id);
                throw;
            }
        }

        private static void Validate(VehicleDto vehicleDto) {
            if(vehicleDto is null)
                throw new ArgumentNullException(nameof(vehicleDto));
        }

        private static decimal CalculateBasicBuyerFee(VehicleDto vehicleDto) {
            decimal feePercentage = 0.10m;
            decimal fee = vehicleDto.BasePrice * feePercentage;

            if (vehicleDto.Type == EnumVehicleType.Common)
                fee = Math.Clamp(fee, 10, 50);
            else if (vehicleDto.Type == EnumVehicleType.Luxury)
                fee = Math.Clamp(fee, 25, 200);

            return fee;
        }

        private static decimal CalculateSpecialFee(VehicleDto vehicleDto) {
            decimal feePercentage = vehicleDto.Type == EnumVehicleType.Common ? 0.02m : 0.04m;
            return vehicleDto.BasePrice * feePercentage;
        }

        private static decimal CalculateAssociationFee(decimal basePrice) {
            if (basePrice <= 500)
                return 5;
            else if (basePrice <= 1000)
                return 10;
            else if (basePrice <= 3000)
                return 15;
            else
                return 20;
        }
    }
}
