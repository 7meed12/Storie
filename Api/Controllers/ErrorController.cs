using Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
      [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponses(code));
        }
    }
}
