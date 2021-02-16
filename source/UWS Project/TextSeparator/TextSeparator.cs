using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using UWS_Project.Model;

namespace UWS_Project.TextSeparator
{
    public class TextSeparator : ITextSeparator
    {
        private readonly Dictionary<string, int> _dictionary = new();
        private readonly List<Word> _words = new();
        private readonly Lazy<Logger> _lazy = new(LogManager.GetCurrentClassLogger);
        private Logger Logger => _lazy.Value;
        private const string ErrorMessage = "Ошибка при обработке текста";
        private readonly char[] _separator =
        {
            ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')',
            '\n', '\r', '\t'
        };
        
        public TextSeparator()
        {
            
        }
        
        public TextSeparator(char[] customSeparator)
        {
            _separator = customSeparator;
        }
        
        public IEnumerable<Word> GetWords(string rawText)
        {
            try
            {
                FillDictionaryUniqueWords(rawText);
                var wordsFromDictionary = _dictionary
                    .Select(kvp => new Word {Value = kvp.Key, Count = kvp.Value});
            
                _words.AddRange(wordsFromDictionary);
            
                return _words;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + e.StackTrace);
                throw new Exception(ErrorMessage);
            }
        }
        
        private void FillDictionaryUniqueWords(string rawText)
        {
            string[] splittedText = rawText.Split(_separator);
            
            foreach (var str in splittedText)
            {
                if(IsWord(str) && !string.IsNullOrEmpty(str))
                    PutWordInDictionary(str);
            }
        }
        
        private bool IsWord(string rawStr)
        {
            return rawStr.All(char.IsLetter);
        }

        private void PutWordInDictionary(string word)
        {
            if (_dictionary.ContainsKey(word))
                _dictionary[word] += 1;
            else
                _dictionary.Add(word, 1);
        }
    }
}