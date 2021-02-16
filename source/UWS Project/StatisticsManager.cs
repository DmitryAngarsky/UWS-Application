using System;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using UWS_Project.Database;
using UWS_Project.HtmlLoader;
using UWS_Project.HtmlParser;
using UWS_Project.Model;
using UWS_Project.TextSeparator;

namespace UWS_Project
{
    public class StatisticsManager
    {
        private readonly Page _page = new();
        public IHtmlLoader Loader;
        public IHtmlParser Parser;
        public ITextSeparator Separator;
        public IRepository<Page> Repository;
        private readonly Lazy<Logger> _lazy = new(LogManager.GetCurrentClassLogger);
        private Logger Logger => _lazy.Value;

        public async void Run()
        {
            try
            {
                GetPage();
                await GetStatistics();
                SavePage();
                OutputStatistics();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void GetPage()
        {
            PrintWelcomeMessage();
            InputPage();
        }
        
        private void PrintWelcomeMessage()
        {
            const string startMessage = "Программа UWS предназначена для получения статистики, по количеству уникальных слов, найденных на введённой вами веб странице. Для того чтобы воспользоваться программой, введите адрес сайта в консоль и нажмите Enter.\n";
            const string firstStepMessage = "Введите адрес веб сайта: ";
            
            Console.WriteLine(startMessage);
            Console.WriteLine(firstStepMessage);
        }

        private void InputPage()
        {
            const string errorMessage = "Строка не может быть пустой!";
            string url = @Console.ReadLine();

            if (string.IsNullOrEmpty(url))
                throw new Exception(errorMessage);

            _page.Url = url;
            
            Console.WriteLine();
        }

        private async Task GetStatistics()
        {
            PrintProcessMessage();
            
            string htmlDocument = await Loader.GetPageContent(_page);
            string pageContent = Parser.GetParsedText(htmlDocument);
            
            _page.Words =  Separator.GetWords(pageContent).ToList();
        }
        
        private void PrintProcessMessage()
        {
            const string processMessage = "Начался подсчёт слов...\n";
            
            Console.WriteLine(processMessage);
        }

        private void SavePage()
        {
            const string errorMessage = "Ошибка при сохранении статистики в базу данных";

            try
            {
                Repository.Create(_page);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
                throw new Exception(errorMessage);
            }
        }

        private void OutputStatistics()
        {
            foreach (var word in _page.Words.OrderByDescending(w => w.Count))
            {
                Console.WriteLine($"{word.Value} - {word.Count}");
            }

            PrintFinalMessage();
        }
        
        private void PrintFinalMessage()
        {
            const string finalMessage = "Подсчёт слов окончен!";
            
            Console.WriteLine("---------------");
            Console.WriteLine();
            Console.WriteLine(finalMessage);
        }
    }
}