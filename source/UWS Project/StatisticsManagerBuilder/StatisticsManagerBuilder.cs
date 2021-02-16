namespace UWS_Project.StatisticsManagerBuilder
{
    public abstract class StatisticsManagerBuilder
    {
        public StatisticsManager StatisticsManager { get; private set; }
        
        public void CreateStatisticsManager()
        {
            StatisticsManager = new StatisticsManager();
        }
        
        public abstract void SetHtmlLoader();
        public abstract void SetHtmlParser();
        public abstract void SetTextSeparator();
        public abstract void SetRepository();
    }
}