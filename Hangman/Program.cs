using System.Reflection;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new WordList();
            var word = list.GetRandomWord();

            var answer = word.ToUpper();
            



            int aboutHalf = (Console.BufferWidth / 2) - 5;

            var linch = new Hangman(10, 8, 7);
            var man = new Man(0);
            //var game = new Game(answer);
            var game = new Game(answer);

            while (true)
            {
                //Draws Linch
                linch.DrawHangman();
                //Finds the postion for where to start drawing the stickman
                var currentCol = linch.ReturnCurrentCol();

                // It inverted here, im not sure why, ill look at it later
                man.CheckHowMany(linch.ReturnHorForHead(), linch.ReturnColForHead());//Draws stickman

                //Draw a visual representasjon of guesses 
                currentCol += 2;
                Console.SetCursorPosition(aboutHalf, currentCol);
                game.DrawGuesses();

                //player guess
                currentCol += 2;
                Console.SetCursorPosition(aboutHalf, currentCol);
                var guess = game.Ask();
                
                //Check if correct
                var correctGuess = game.CheckIfCorGuess(guess);
                game.WinLose(man.Complete,answer);
                if (!correctGuess)
                    man.WrongAnswer();

                Console.Clear();
            }
        }


    }
}