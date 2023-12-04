using System.Collections.Immutable;

namespace Hangman
{
    internal class Game
    {
        public char[] guesses;
        private string _answer;

        public Game(string answer)
        {
            // init
            _answer = answer;
            guesses = new char[_answer.Length];
            for (int i = 0; i < guesses.Length; i++)
            {
                guesses[i] = '_';
            }
        }

        public void WinLose(bool complete, string answer)
        {
            //Checks win and lose conditions
            _answer = _answer.ToUpper();
            string guessedWord = new string(guesses).ToUpper();

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


        public char Ask()
        {

            // User input
            while (true)
            {

                char userinp;
                //  cheking if char / userinput = console.readline()
                if (char.TryParse(Console.ReadLine(), out userinp))
                {
                    // prolly a better way to do it.
                    // Whats happening here is char being thrown around just to make it uppercase
                    //rest of the program checks only in upper
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
            for (int i = 0; i < guesses.Length; i++)
            {
                Console.Write(guesses[i] + " ");
            }

            Console.WriteLine();
        }


        public bool CheckIfCorGuess(char search)
        {
            //Checks if userinp/search is inside the answer
            bool correct = false;
            for (int i = 0; i < guesses.Length; i++)
            {
                if (_answer[i] == search)
                {
                    guesses[i] = search;
                    // I tried return true here but it would only save the first mention of search
                    // But what if there are 2 "D" or 5 "A", it would stop at the first.
                    correct = true;
                }
            }

            bool ans = correct ? true : false;
            return ans;
        }
    }
}