using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PC_assignment
{
    public interface IPoliciesRepository
    {
        IPolicy GetPolicyFromFile(string filePath);
    }
    public class PoliciesRepository : IPoliciesRepository
    {
        public IPolicy GetPolicyFromFile(string filePath)
        {
            string policyJson = File.ReadAllText(filePath);

            var policy = JsonConvert.DeserializeObject<GeneralPolicy>(policyJson,
                new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Life:
                    return JsonConvert.DeserializeObject<LifeInsurancePolicy>(policyJson,
                        new StringEnumConverter());

                case PolicyType.Travel:
                    return JsonConvert.DeserializeObject<TravelInsurancePolicy>(policyJson,
                        new StringEnumConverter());

                case PolicyType.Health:
                    return JsonConvert.DeserializeObject<HealthInsurancePolicy>(policyJson,
                        new StringEnumConverter()); ;

            }

            return policy;
        }
    }
}
