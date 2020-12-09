using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task.API.Application.Commands;
using Task.API.Application.Queries;
using Task.API.Model;
using Task.Domain.AggregatesModel.ToDoItemAggregate;
using Task.Infrastructure;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly ITaskDbContext _dbContext;
        private readonly ITaskQueries _taskQueries;
        private readonly IMediator _mediator;

        public ToDoController(ILogger<ToDoController> logger, 
            ITaskDbContext dbContext, 
            ITaskQueries taskQueries,
            IMediator mediator)
        {
            _logger = logger;
            _dbContext = dbContext;
            _taskQueries = taskQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> GetList()
        {
            var todoItems = await _taskQueries.GetTasksAsync();

            return Ok(todoItems);

            //var data = await this._dbContext.Query<ToDoItem>().Select(x => new ToDoItemDto
            //{
            //    Id = x.Id,
            //    Description = x.Description,
            //    DueDate = x.DueDate,
            //    Title = x.Title
            //}).ToListAsync();

            //return data;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] AddTaskCommand command)
        {
            var response = await _mediator.Send<bool>(command);

            return Ok(response);
        }

        //[Route("create")]
        //[HttpPost]
        //public async Task<bool> Create(ToDoItemDto dto)
        //{
        //    var todoItem = new ToDoItem
        //    {
        //        Description = dto.Description,
        //        DueDate = dto.DueDate,
        //        Title = dto.Title
        //    };
        //    await _dbContext.Query<ToDoItem>().AddAsync(todoItem);
        //    var result = await _dbContext.SaveChangesAsync();
        //    return result > 0 ? true : false;
        //}
    }
}
