using System;
using HtmlAgilityPack;
using NLog;

namespace UWS_Project.HtmlParser
{
    public class HtmlParser : IHtmlParser
    {
        private readonly Lazy<Logger> _lazy = new(LogManager.GetCurrentClassLogger);
        private Logger Logger => _lazy.Value;
        private const string ErrorMessage = "Не удалось получить текст страницы";
        
        public string GetParsedText(string htmlDocument)
        {
            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlDocument);
                
                return htmlDoc.DocumentNode.InnerText;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
                throw new Exception(ErrorMessage);
            }
        }
    }
}