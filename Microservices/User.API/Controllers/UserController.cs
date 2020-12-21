using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task.Infrastructure;
using User.API.Application.Commands;
using User.API.Application.Queries;
using User.Infrastructure;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserDbContext _dbContext;
        private readonly IUserQueries _userQueries;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger,
            IUserDbContext dbContext,
            IUserQueries userQueries,
            IMediator mediator)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userQueries = userQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetList()
        {
            var users = await _userQueries.GetUsersAsync();

            return Ok(users);
        }

        [Route("incrementtaskcount/{id}")]
        [HttpPatch]
        public async Task<ActionResult<bool>> IncrementTaskNumber([FromRoute] IncrementTaskCountCommand command)
        {
            var response = await _mediator.Send<bool>(command);

            return Ok(response);
        }

        [Route("decrementtaskcount/{id}")]
        [HttpPatch]
        public async Task<ActionResult<bool>> DecrementTaskNumber([FromRoute] DecrementTaskCountCommand command)
        {
            var response = await _mediator.Send<bool>(command);

            return Ok(response);
        }
    }
}
