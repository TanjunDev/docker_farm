using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("GenerateGuid")]
    public IActionResult Get()
    {
        // Generate a guid and return it
        return Ok(Guid.NewGuid());
    }
}
