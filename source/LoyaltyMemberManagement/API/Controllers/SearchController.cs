using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Queries.Member;
using Application.Services.Queries.Member.ViewModel;
using Domain.AggregatesModel.MemberAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "Search & List")]
    public class SearchController : BaseController
    {





        [HttpGet("{minPoint}/{accountStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
    Summary = "Search members by using criteria",
    Description = "Search members by using criteria",
    OperationId = "Members.GetAllWithMinPoint",
    Tags = new[] { "Search & List" })
            ]
        public async Task<ActionResult<MemberListVm>> GetAllWithMinPoint(decimal minPoint, string accountStatus)
        {
            var result = await Mediator.Send(new ListWithMinPointAndAccountStatusQuery { MinPoint = minPoint, AccountStatus = accountStatus });

            return Ok(result);
        }

        [Route("ListAll")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
    Summary = "List all Members",
    Description = "List all Members",
    OperationId = "Members.GetAll",
    Tags = new[] { "Search & List" })
            ]
        public async Task<ActionResult<MemberListVm>> GetAll()
        {
            var result = await Mediator.Send(new ListAllMembersQuery {});

            return Ok(result);
        }

    }
}