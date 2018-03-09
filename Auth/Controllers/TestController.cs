using System;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("/test")]
    public class TestController: Controller
    {
        [HttpGet("string")]
        public string GetString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}