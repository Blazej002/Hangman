using System.Runtime.InteropServices;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "Blazej";
            var answer = word.ToUpper();
            var guesses = new char[word.Length];


            for (int i = 0; i < guesses.Length; i++)
            {
                guesses[i] = '_';
            }

            int aboutHalf = (Console.BufferWidth / 2) - 5;


            bool checkIfCorrect = true;
            int wrongs = 0;
            var game = new Hangman(10, 7, 7);
            var man = new Man(0);


            while (true)
            {
                game.DrawHangman();

                var currentCol = game.ReturnCurrentCol();

                if (!checkIfCorrect)
                    man.WrongAnswer();
                man.CheckHowMany(game.ReturnColForHead(), game.ReturnHorForHead());



                //Draw a visual representasjon of guesses 
                currentCol += 2;
                Console.SetCursorPosition(aboutHalf, currentCol);
                for (int i = 0; i < answer.Length; i++)
                {
                    Console.Write(guesses[i] + " ");
                }

                Console.WriteLine();
                currentCol += 2;
                Console.SetCursorPosition(aboutHalf, currentCol);


                //player guess
                var guess = char.Parse(Console.ReadLine());

                //Check if correct
                var a = char.ToUpper(guess);
                char search = Convert.ToChar(a);
                checkIfCorrect = false;

                for (int i = 0; i < word.Length; i++)
                {
                    if (answer[i] == search)
                    {
                        guesses[i] = search;
                        checkIfCorrect = true;
                    }
                }

                Console.Clear();
            }
        }

        public void DrawHangman()
        {
        }
    }
}