using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("/test")]
    public class TestController: Controller
    {
        [HttpGet("me")]
        public string GetMe()
        {
            return string.Join(", ", User.Claims);
        }
    }
}