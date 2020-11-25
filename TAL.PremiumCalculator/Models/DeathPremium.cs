using System;

namespace TAL.PremiumCalculator.Models
{
    public class DeathPremium
    {
        public DateTime dob { get; set; }
        public decimal deathCoverAmount { get; set; }
        public int occupationId { get; set; }
    }

}
