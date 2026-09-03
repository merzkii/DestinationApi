using DestinationApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DestinationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteFinder _route;

        public RouteController(IRouteFinder route)
        {
            _route = route;
        }

        [HttpGet]
        public IActionResult FindRoute([FromQuery] string source, [FromQuery] string destination) 
        { 
             var result = _route.FindRoute(source.ToUpper(), destination.ToUpper());

            if (result == null) 
            { 
                return NotFound();
            }

            return Ok(new
            {
                route = String.Join("->", result.Route),
                moves = result.MoveCount,
                totalFee = result.TotalFee,
            });
        }
    }
}
