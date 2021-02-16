using System.Collections.Generic;

namespace UWS_Project.Model
{
    public class Page
    {
        public int PageId { get; set; }
        public string Url { get; set; }
        
        public IEnumerable<Word> Words { get; set; }
    }
}