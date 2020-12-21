using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Application.Commands
{
    public class IncrementTaskCountCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
