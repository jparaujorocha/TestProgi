namespace BidCalculationTool.Presentation.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ApiBaseController {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService) {
            _vehicleService = vehicleService;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateTotalCost([FromBody] VehicleDto vehicle) {
            try {
                var totalCost = await _vehicleService.CalculateTotalCost(vehicle);
                return Ok(new { totalCost });
            }
            catch (Exception ex) {
                return ThrowErrorToApi(ex);
            }
        }
    }
}
