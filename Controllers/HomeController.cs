using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using NHS.Login.Client;

namespace NHS.Login.Dotnet.Core6.Sample.Controllers
{

    public class HomeController
    {
        ClaimsReader _claimsReader;
        public HomeController(ClaimsReader claimsReader)
        {
            _claimsReader = claimsReader;
        }


        [HttpGet]
        [Authorize]
        public async IAsyncEnumerable<Claim> GetAsync()
        {
            await foreach (var claim in _claimsReader.GetAsync())
                yield return claim;
        }


    }
}
