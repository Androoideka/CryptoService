using CryptoService.Core.Responses;
using CryptoService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoService.API.Controllers
{
    [Route("symbols")]
    [ApiController]
    public class SymbolController : ControllerBase
    {
        private readonly CryptocurrencyService _service;
        public SymbolController(CryptocurrencyService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SymbolResponse>>> GetAll()
        {
            IEnumerable<SymbolResponse> response = await _service.GetAll();
            return Ok(response);
        }
    }
}
