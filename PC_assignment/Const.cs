using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_assignment
{
    public static class LogMessages
    {
        public static class ProgramLogMessages
        {
            public const string RatingEngineInit = "Insurance Rating System Starting...";
            public const string NoRatingProduced = "No rating produced.";
        }

        public static class RatingEngineLogMessages
        {
            public const string ValidatingPolicy = "Validating policy.";
            public const string StartingRate = "Starting rate.";
            public const string LoadingPolicy = "Loading policy.";
            public const string RatingCompleted = "Rating completed.";
            public const string UnknownPolicyType = "Unknown policy type";

            // health policy
            public const string RatingHealthPolicy = "Rating HEALTH policy...";
            public const string HealthPolicyMustSpecifyGender = "Health policy must specify Gender";

            // travel policy
            public const string RatingTravelPolicy = "Rating TRAVEL policy...";
            public const string TravelPolicyMustSpecifyDays = "Travel policy must specify Days.";
            public const string TravelPolicyDaysLimit = "Travel policy cannot be more than 180 Days.";
            public const string TravelPolicyMustSpecifyCountry = "Travel policy must specify country.";

            // life policy
            public const string RatingLifePolicy = "Rating LIFE policy...";
            public const string LifePolicyMustIncludeBirthDate = "Life policy must include Date of Birth.";
            public const string LifePolicyAgeLimit = "Max eligible age for coverage is 100 years.";
            public const string LifePolicyMustIncludeAmount = "Life policy must include an Amount.";
        }
        
    }
}
