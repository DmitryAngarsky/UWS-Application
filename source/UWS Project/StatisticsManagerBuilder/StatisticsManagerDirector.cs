namespace UWS_Project.StatisticsManagerBuilder
{
    public class StatisticsManagerDirector
    {
        public StatisticsManager Construct(StatisticsManagerBuilder statisticsManagerBuilder)
        {
            statisticsManagerBuilder.CreateStatisticsManager();
            statisticsManagerBuilder.SetHtmlLoader();
            statisticsManagerBuilder.SetHtmlParser();
            statisticsManagerBuilder.SetTextSeparator();
            statisticsManagerBuilder.SetRepository();
            
            return statisticsManagerBuilder.StatisticsManager;
        }
    }
}