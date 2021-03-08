using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Commands;
using Application.Services.Commands.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName= "Earn & Burn")]
    public class AccountController : BaseController
    {
       
        [Route("CollectPoint")]
        [HttpPut]
        public async Task<IActionResult> CollectPointToAccount([FromBody] CollectPointCommand command)
        {

            var result = await Mediator.Send(command);

            return Ok(result);
        }



        [Route("RedeemPoint")]
        [HttpPut]
        public async Task<IActionResult> RedeemPointToAccount([FromBody] RedeemPointCommand command)
        {

            var result = await Mediator.Send(command);

            return Ok(result);
        }



    }





}