using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{    
    public abstract class BaseController : ControllerBase
    {
        public async Task <IActionResult> ExecuteMethod(Action action) 
        {
            try
            {
                Log.Information(action.GetType().Name);

                action();

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Error {$action}", ex.Message);

                throw new Exception("Server Error");
            }
        }
    }
}
