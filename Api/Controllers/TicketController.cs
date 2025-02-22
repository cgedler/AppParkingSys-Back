﻿using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.App;

namespace Api.Controllers
{
    /// <summary>
    ///  Class <c>TicketController</c> handles HTTP requests and interacts with the service.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        public TicketController(ITicketService ticketService, IMapper mapper, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketModel>>> Get()
        {
            var ticket = await _ticketService.GetAll();
            var mappedTicket = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketModel>>(ticket);
            return Ok(mappedTicket);
        }
        // GET: api/<UserController>/topay
        [HttpGet("topay")]
        [ActionName(nameof(GetToPay))]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetToPay()
        {
            var ticket = await _ticketService.GetToPay();
            var mappedTicket = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketModel>>(ticket);
            return Ok(mappedTicket);
        }
        // GET api/<TicketController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketModel>> Get(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            var mappedTicket = _mapper.Map<Ticket, TicketModel>(ticket);
            return Ok(mappedTicket);
        }
        // POST
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<TicketModel>> Post([FromBody] TicketSaveModel ticket)
        {
            try
            {
                var createdTicket = await _ticketService.RegisterTicket(_mapper.Map<TicketSaveModel, Ticket>(ticket));
                return Ok(_mapper.Map<Ticket, TicketModel>(createdTicket));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketModel>> Put(int id, [FromBody] TicketModel ticket)
        {
            _logger.LogInformation("Inside put");
            if (id != ticket.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedTicket = await _ticketService.UpdateTicket(id, _mapper.Map<TicketModel, Ticket>(ticket));
                return Ok(_mapper.Map<Ticket, TicketModel>(updatedTicket));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
