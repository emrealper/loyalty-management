using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Commands;
using Application.Services.Commands.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        [Route("CollectPoint")]
        [HttpPut]
        [SwaggerOperation(
   Summary = "Collects points to the Account", Description = "Collects points to the Account",
   OperationId = "Account.CollectPoint", Tags = new[] { "Earn & Burn" })
            ]
        public async Task<IActionResult> CollectPointToAccount([FromBody] CollectPointCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Route("RedeemPoint")]
        [HttpPut]
        [SwaggerOperation(
    Summary = "Redeems points from the Account", Description = "Redeems points from the Account", 
    OperationId = "Account.RedeemPoint", Tags = new[] { "Earn & Burn" })
            ]
        public async Task<IActionResult> RedeemPointToAccount([FromBody] RedeemPointCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}