using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task.API.Application.Commands;
using Task.API.Application.Queries;
using Task.API.Model;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
namespace Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly ITaskQueries _taskQueries;
        private readonly IMediator _mediator;

        public ToDoController(ILogger<ToDoController> logger, 
            ITaskQueries taskQueries,
            IMediator mediator)
        {
            _logger = logger;
            _taskQueries = taskQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> GetList()
        {
            var todoItems = await _taskQueries.GetTasksAsync();

            return Ok(todoItems);
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] AddTaskCommand command)
        {
            var response = await _mediator.Send<bool>(command);

            return Ok(response);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromRoute] DeleteTaskCommand command)
        {
            var response = await _mediator.Send<bool>(command);

            return Ok(response);
        }
    }
}
