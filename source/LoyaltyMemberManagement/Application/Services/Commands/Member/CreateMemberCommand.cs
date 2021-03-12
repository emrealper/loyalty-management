using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services.Commands
{
    public class CreateMemberCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
