using System.Collections.Generic;
using UWS_Project.Model;

namespace UWS_Project.TextSeparator
{
    public interface ITextSeparator
    {
        IEnumerable<Word> GetWords(string rawText);
    }
}