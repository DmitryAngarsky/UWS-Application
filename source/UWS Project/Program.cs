using System;
using UWS_Project.StatisticsManagerBuilder;

namespace UWS_Project
{
    class Program
    {
        static void Main()
        {
            StatisticsManagerDirector statisticsManagerDirector = new StatisticsManagerDirector();
            UniqueWordStatisticsManagerBuilder statisticsManagerBuilder = new UniqueWordStatisticsManagerBuilder();
            
            var statisticsManager = statisticsManagerDirector.Construct(statisticsManagerBuilder);
            statisticsManager.Run();
            Console.ReadKey();
        }
    }
}