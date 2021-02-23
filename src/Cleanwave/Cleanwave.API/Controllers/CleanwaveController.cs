using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleanwave.API.Controllers
{
    public class CleanwaveController : BaseController
    {
        [HttpGet]
        public async void Get()
        {
            await Mediator.Send(null);
        }
    }
}
