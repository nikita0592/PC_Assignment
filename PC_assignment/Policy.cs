using PC_assignment;
using System;

namespace TestRating
{

    public interface IPolicy
    {

        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal CalcRating();
        public bool ValidatePolicy();
        //public string FullName { get; set; }
        //public DateTime DateOfBirth { get; set; }

        //#region Life Insurance
        //public bool IsSmoker { get; set; }
        //public decimal Amount { get; set; }
        //#endregion

        //#region Travel
        //public string Country { get; set; }
        //public int Days { get; set; }
        //#endregion

        //#region Health
        //public string Gender { get; set; }
        //public decimal Deductible { get; set; }
        //#endregion

    }

    public class GeneralPolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public decimal CalcRating()
        {
            return 0;
        }

        public bool ValidatePolicy()
        {
            throw new NotImplementedException();
        }
    }

    public class HealthInsurancePolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal Deductible { get; set; }

        public decimal CalcRating()
        {
            decimal Rating = 0;

            if (Gender == "Male")
            {
                if (Deductible < 500)
                {
                    Rating = 1000m;
                }
                Rating = 900m;
            }
            else
            {
                if (Deductible < 800)
                {
                    Rating = 1100m;
                }
                Rating = 1000m;
            }

            return Rating;
        }

        public bool ValidatePolicy()
        {
            return String.IsNullOrEmpty(Gender);
        }
    }

    public class TravelInsurancePolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public int Days { get; set; }

        public decimal CalcRating()
        {
            var Rating = Days * 2.5m;

            if (Country == "Italy")
            {
                Rating *= 3;
            }

            return Rating;
        }

        public bool ValidatePolicy()
        {
            if (Days <= 0)
            {
                //Console.WriteLine("Travel policy must specify Days.");
                throw new Exception(LogMessages.RatingEngineLogMessages.TravelPolicyMustSpecifyDays);
            }
            if (Days > 180)
            {
                //Console.WriteLine("Travel policy cannot be more then 180 Days.");
                throw new Exception(LogMessages.RatingEngineLogMessages.TravelPolicyDaysLimit);
            }
            if (String.IsNullOrEmpty(Country))
            {
                //Console.WriteLine("Travel policy must specify country.");
                throw new Exception(LogMessages.RatingEngineLogMessages.TravelPolicyMustSpecifyCountry);
            }

            return true;
        }
    }

    public class LifeInsurancePolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }

        public decimal CalcRating()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < DateOfBirth.Day ||
                DateTime.Today.Month < DateOfBirth.Month)
            {
                age--;
            }

            decimal baseRate = Amount * age / 200;

            if (IsSmoker)
            {
                return baseRate * 2;
               
            }

            return baseRate;
        }

        public bool ValidatePolicy()
        {
            if (DateOfBirth == DateTime.MinValue)
            {
                //Console.WriteLine("Life policy must include Date of Birth.");
                throw new Exception(LogMessages.RatingEngineLogMessages.LifePolicyMustIncludeBirthDate);
            }
            if (DateOfBirth < DateTime.Today.AddYears(-100))
            {
                throw new Exception(LogMessages.RatingEngineLogMessages.LifePolicyAgeLimit);
            }
            if (Amount == 0)
            {
                throw new Exception(LogMessages.RatingEngineLogMessages.LifePolicyMustIncludeAmount);
            }

            return true;
        }
    }

}
