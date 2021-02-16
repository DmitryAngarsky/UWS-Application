using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NLog;
using UWS_Project.Model;

namespace UWS_Project.HtmlLoader
{
    public class HtmlLoader : IHtmlLoader
    {
        private readonly HttpClient _client = new();
        private readonly Lazy<Logger> _lazy = new(LogManager.GetCurrentClassLogger);
        private Logger Logger => _lazy.Value;
        private const string ErrorMessage = "Не удалось получить доступ к запрашиваемому ресурсу";

        public async Task<string> GetPageContent(Page page)
        {
            var response = await GetResponseMessageAsync(page.Url);
            bool isValidResponse = response != null
                                   && response.StatusCode == HttpStatusCode.OK;

            if (isValidResponse)
                return await response.Content.ReadAsStringAsync();

            return string.Empty;
        }

        private async Task<HttpResponseMessage> GetResponseMessageAsync(string url)
        {
            try
            {
                return await _client.GetAsync(url);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
                throw new Exception(ErrorMessage);
            }
        }
    }
}