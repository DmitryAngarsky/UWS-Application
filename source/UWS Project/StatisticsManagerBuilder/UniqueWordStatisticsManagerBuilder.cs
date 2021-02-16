using UWS_Project.Database;
using UWS_Project.Database.Context;
using UWS_Project.Model;

namespace UWS_Project.StatisticsManagerBuilder
{
    public class UniqueWordStatisticsManagerBuilder : StatisticsManagerBuilder
    {
        public override void SetHtmlLoader()
        {
            StatisticsManager.Loader = new HtmlLoader.HtmlLoader();
        }

        public override void SetHtmlParser()
        {
            StatisticsManager.Parser = new HtmlParser.HtmlParser();
        }

        public override void SetTextSeparator()
        {
            StatisticsManager.Separator = new TextSeparator.TextSeparator();
        }

        public override void SetRepository()
        {
            StatisticsManager.Repository = new EFRepository<Page>(new ApplicationContext());
        }
    }
}