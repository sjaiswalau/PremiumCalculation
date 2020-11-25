using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TAL.PremiumCalculator.Common
{
    public class Enums
    {
        public enum Occupation
        {
            [Description("LightManual")]
            Cleaner = 1,
            [Description("Professional")]
            Doctor = 2,
            [Description("WhiteCollar")]
            Author = 3,
            [Description("HeavyManual")]
            Farmer = 4,
            [Description("HeavyManual")]
            Mechanic = 5,
            [Description("LightManual")]
            Florist = 6
        }

        public enum OccupationRating
        {
            [Description("1.0")]
            Professional = 1,
            [Description("1.25")]
            WhiteCollar = 2,
            [Description("1.5")]
            LightManual = 3,
            [Description("1.75")]
            HeavyManual = 4
        }
    }
}
