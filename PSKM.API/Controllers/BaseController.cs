using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Models;

namespace PSKM.API.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
        // This is a base controller that provides common functionality for all controllers in the API.
        protected async Task<IActionResult> HandleRequest<T>(Func<Task<ResponseModel<T>>> action)
        {
                try
                {
                        var result = await action();
                        return ApiResponse(result);
                }
                catch (Exception ex)
                {

                        return StatusCode(500, new { message = ex.Message });
                }
        }

        protected IActionResult ApiResponse<T>(ResponseModel<T> response) =>
                 StatusCode((int)response.StatusCode, response);
        
}
