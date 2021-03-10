using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Commands;
using Application.Services.Commands.Account;
using Application.Services.Commands.Bulk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName="Enrollment")]
    public class MemberController : BaseController
    {


        [Route("CreateMember")]
        [HttpPost]
        [SwaggerOperation(
    Summary = "Enrolls a new Member",
    Description = "Enrolls a new Member",
    OperationId = "Member.Create",
    Tags = new[] { "Enrollment" })
]
        public async Task<IActionResult> CreateNewMember([FromBody]CreateMemberCommand command)
        {
            
            var result=await Mediator.Send(command);

            return Ok(result);
        }


        [Route("CreateNewAccount")]
        [HttpPost]
        [SwaggerOperation(
    Summary = "Enrolls a new Account",
    Description = "Enrolls a new Account for defined Member",
    OperationId = "Account.Create",
    Tags = new[] { "Enrollment" })
            ]
        public async Task<IActionResult> CreateNewAccountForDefinedMember([FromBody] CreateAccountCommand command)
        {

            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [Route("MembersBulkCreate")]
        [HttpPost]
        [SwaggerOperation(
    Summary = "Enrolls bulk members",
    Description = "Enrolls bulk members",
    OperationId = "Member.BulkCreate",
    Tags = new[] { "Enrollment" })
            ]
        public async Task<IActionResult> CreateBulkMembers([FromBody] IReadOnlyList<CreateBulkMemberCommand> commands)
        {

            foreach(var command in commands)
            await Mediator.Send(command);

            return Ok(true);
        }

    }
}