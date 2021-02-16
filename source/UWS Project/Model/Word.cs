using System.Collections.Generic;

namespace UWS_Project.Model
{
    public class Word
    {
        public int WordId { get; set; }
        public string Value { get; set; }
        public int Count { get; set; }
        
        public Page Page { get; set; }
    }
}