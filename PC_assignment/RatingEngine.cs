using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PC_assignment;
using System;
using System.IO;
using System.Reflection;

namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private IPoliciesRepository _policiesRepository;

        public RatingEngine(IPoliciesRepository policiesRepository)
        {
            _policiesRepository = policiesRepository;
        }

        public decimal Rating { get; set; }
        public void Rate()
        {
            // log start rating
            Logger.Log([LogMessages.RatingEngineLogMessages.StartingRate, LogMessages.RatingEngineLogMessages.LoadingPolicy]);

            // load policy - open file policy.json
            var policy = _policiesRepository.GetPolicyFromFile("policy.json");

            switch (policy)
            {
                case HealthInsurancePolicy healthPolicy:
                    Logger.Log([LogMessages.RatingEngineLogMessages.RatingHealthPolicy, LogMessages.RatingEngineLogMessages.ValidatingPolicy]);

                    var isValidPolicy = healthPolicy.ValidatePolicy();
                    if (isValidPolicy)
                    {
                        Logger.Log(LogMessages.RatingEngineLogMessages.HealthPolicyMustSpecifyGender);
                        return;
                    }

                    Rating = healthPolicy.CalcRating();
                    break;

                case TravelInsurancePolicy travelPolicy:
                    Logger.Log([LogMessages.RatingEngineLogMessages.RatingTravelPolicy, LogMessages.RatingEngineLogMessages.ValidatingPolicy]);

                    try
                    {
                        travelPolicy.ValidatePolicy();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.Message);
                        return;
                    }

                    Rating = travelPolicy.CalcRating();

                    break;

                case LifeInsurancePolicy lifePolicy:
                    Logger.Log([LogMessages.RatingEngineLogMessages.RatingLifePolicy, LogMessages.RatingEngineLogMessages.ValidatingPolicy]);


                    try
                    {
                        lifePolicy.ValidatePolicy();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.Message);
                        return;
                    }

                    Rating = lifePolicy.CalcRating();

                    break;

                default:
                    Logger.Log(LogMessages.RatingEngineLogMessages.UnknownPolicyType);
                    break;
            }

            Logger.Log(LogMessages.RatingEngineLogMessages.RatingCompleted);
        }
    }
}
