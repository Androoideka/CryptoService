using CryptoService.Core.Requests;
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

        [HttpGet("quotes")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<QuoteResponse>>> GetQuotes([FromQuery] IEnumerable<string> id)
        {
            QuoteRequest quoteRequest = new QuoteRequest(id);
            IEnumerable<QuoteResponse> response = await _service.GetQuotes(quoteRequest);
            return Ok(response);
        }
    }
}
