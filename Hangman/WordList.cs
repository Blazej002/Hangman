using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class WordList
    {
        //list of words being used
        private List<string> wordList = new List<string>
        {
            "Avadacadavra",
            "David",
            "James",
            "Bitch",
            "Sun",
            "Moon"
        };
        //choses random one
        public string GetRandomWord()
        {
            var ran = new Random();
            var randomIndex = ran.Next(0, wordList.Count);
            return wordList[randomIndex];
        }
    }
}