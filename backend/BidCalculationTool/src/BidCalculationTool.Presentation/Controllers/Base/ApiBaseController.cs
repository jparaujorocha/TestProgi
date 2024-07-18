namespace BidCalculationTool.Presentation.Controllers.Base {
    [ExcludeFromCodeCoverage]
    public class ApiBaseController : ControllerBase {
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public ObjectResult ThrowErrorToApi(Exception exception) {
            return exception switch {
                ArgumentNullException validationException => StatusCode(StatusCodes.Status400BadRequest, $"Error: {exception.Message}"),
                _ => StatusCode(500, new { exception.Message })
            };
        }
    }
}
