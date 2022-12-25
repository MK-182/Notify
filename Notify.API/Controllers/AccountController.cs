using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nofity.Core;
using Nofity.Core.Services;

namespace Notify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task Get(string email, string password)
        {
            await _accountService.CreateAccount(email, password).ConfigureAwait(false);
        }


        [HttpGet]
        [Route("Reminder")]
        public async Task Get(string email, string description, DateTime notifyAt)
        {
            await _accountService.AddReminder(new AccountId(email), description, notifyAt).ConfigureAwait(false);
        }
    }
}