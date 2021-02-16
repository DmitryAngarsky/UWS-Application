using System.Threading.Tasks;
using UWS_Project.Model;

namespace UWS_Project.HtmlLoader
{
    public interface IHtmlLoader
    {
        Task<string> GetPageContent(Page page);
    }
}