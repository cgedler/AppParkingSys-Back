using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    /// <summary>
    ///  Class <c>PriceController</c> handles HTTP requests and interacts with the service.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly ILogger<PriceController> _logger;
        private readonly IPriceService _priceService;
        private readonly IMapper _mapper;
        public PriceController(IPriceService priceService, IMapper mapper, ILogger<PriceController> logger)
        {
            _priceService = priceService;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<PriceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceModel>>> Get()
        {
            var price = await _priceService.GetAll();

            var mappedPrice = _mapper.Map<IEnumerable<Price>, IEnumerable<PriceModel>>(price);

            return Ok(mappedPrice);
        }
        // GET api/<PriceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceModel>> Get(int id)
        {
            var price = await _priceService.GetPriceById(id);
            var mappedPrice = _mapper.Map<Price, PriceModel>(price);
            return Ok(mappedPrice);
        }
        // POST api/<PriceController>
        [HttpPost]
        public async Task<ActionResult<PriceModel>> Post([FromBody] PriceSaveModel price)
        {
            try
            {
                _logger.LogInformation("Inside post");
                var createdPrice = await _priceService.RegisterPrice(_mapper.Map<PriceSaveModel, Price>(price));
                return Ok(_mapper.Map<Price, PriceModel>(createdPrice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<PriceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PriceModel>> Put(int id, [FromBody] PriceModel price)
        {
            _logger.LogInformation("Inside put");
            if (id != price.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedPrice = await _priceService.UpdatePrice(id, _mapper.Map<PriceModel, Price>(price));
                return Ok(_mapper.Map<Price, PriceModel>(updatedPrice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE api/<PriceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PriceModel>> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Inside delete");
                var price = await _priceService.DeletePrice(id);
                return Ok("Eliminated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
