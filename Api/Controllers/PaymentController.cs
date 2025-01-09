using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    ///  Class <c>PaymentController</c> handles HTTP requests and interacts with the service.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentService paymentService, IMapper mapper, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _logger = logger;
        }
        // POST api/<PaymentController>
        [HttpPost]
        public async Task<ActionResult<PaymentModel>> Post([FromBody] PaymentSaveModel payment)
        {
            try
            {
                _logger.LogInformation("Inside post");
                var createdPayment = await _paymentService.RegisterPayment(_mapper.Map<PaymentSaveModel, Payment>(payment));
                return Ok(_mapper.Map<Payment, PaymentModel>(createdPayment));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
