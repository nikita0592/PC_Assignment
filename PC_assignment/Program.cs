using PC_assignment;
using System;

namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {
            var policiesRepository = new PoliciesRepository();
            Logger.Log(LogMessages.ProgramLogMessages.RatingEngineInit);

            var engine = new RatingEngine(policiesRepository);
            engine.Rate();

            if (engine.Rating > 0)
            {
                Logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                Logger.Log(LogMessages.ProgramLogMessages.NoRatingProduced);
            }

        }
    }
}
