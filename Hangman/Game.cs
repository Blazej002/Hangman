using System.Collections.Immutable;

namespace Hangman
{
    internal class Game
    {
        public char[] Guesses;
        private string _answer;
        public List<char> Wrongs;

        public Game(string answer)
        {
            // init
            _answer = answer;
            Guesses = new char[_answer.Length];
            Wrongs = new List<char>();
            for (int i = 0; i < Guesses.Length; i++)
            {
                Guesses[i] = '_';
            }
        }

        public void WinLose(bool complete, string answer)
        {
            //Checks win and lose conditions
            _answer = _answer.ToUpper();
            string guessedWord = new string(Guesses).ToUpper();

            if (complete)
            {
                Console.Clear();
                Console.WriteLine("Game over... The word was {0}", answer);
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (guessedWord == _answer)
            {
                Console.Clear();
                Console.WriteLine("You won!!!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void DrawWrongs()
        {
            foreach (var wrong in Wrongs)
            {
                Console.Write(wrong + " ");
            }

            Console.WriteLine();
        }


        public char Ask()
        {
            // User input
            while (true)
            {
                char userinp;
                //cheking if its a char / userinput = console.readline()
                if (char.TryParse(Console.ReadLine(), out userinp))
                {
                    // prolly a better way to do it.
                    // Whats happening here is char being thrown around just to make it uppercase
                    //rest of the program works by checking only uppercase letters
                    var x = userinp.ToString();
                    var y = x.ToUpper();
                    var z = char.Parse(y);
                    char d = z;
                    return z;
                }

                Console.WriteLine("Its not a letter! Try again");
            }
        }


        public void DrawGuesses()
        {
            for (int i = 0; i < Guesses.Length; i++)
            {
                Console.Write(Guesses[i] + " ");
            }

            Console.WriteLine();
        }


        public bool CheckIfCorGuess(char search)
        {
            //Checks if userinp/search is inside the answer
            bool correct = false;
            for (int i = 0; i < Guesses.Length; i++)
            {
                if (_answer[i] == search)
                {
                    Guesses[i] = search;
                    // I tried return true here but it would only save the first mention of search
                    // But what if there are 2 "D" or 5 "A", it would stop at the first.
                    correct = true;
                }

                foreach (var wrong in Wrongs)
                {
                    if (wrong == search)
                    {
                        correct = true;
                    }
                }
            }

            if (!correct)
            {
                Wrongs.Add(search);
            }

            bool ans = correct ? true : false;
            return ans;
        }
    }
}