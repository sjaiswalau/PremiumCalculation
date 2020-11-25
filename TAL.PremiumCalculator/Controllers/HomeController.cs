using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAL.PremiumCalculator.Common;
using TAL.PremiumCalculator.Models;

namespace TAL.PremiumCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(DeathPremium request)
        {
            string occupationRatingName = EnumUtils.GetEnumDescription<Enums.Occupation>(EnumUtils.GetName((Enums.Occupation)request.occupationId));
            decimal rateFactor =
                Convert.ToDecimal(EnumUtils.GetEnumDescription<Enums.OccupationRating>(occupationRatingName));
            DateTime zeroTime = new DateTime(1,1,1);
            TimeSpan span = DateTime.Now - request.dob;
            int ageInYears = (zeroTime + span).Year - 1;
            if (ageInYears > 0)
            {
                decimal premium = (request.deathCoverAmount * rateFactor * ageInYears) / (1000 * 12);
                return Ok(premium);
            }
            return Ok(-1);
        }
    }
}
