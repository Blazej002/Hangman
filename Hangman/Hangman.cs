namespace Hangman
{
    internal class Hangman
    {
        private int Height;

        private int Width;

        // Start point for currentCol
        private int CurrentCol;

        // End point CurrentCol
        private int CurrentAfter;

        // Copy of currentCol
        private int CurrentCopy;

        // Head position for the future
        private int ColHead;
        private int HorHead;

        public Hangman(int height, int width, int currentCol)
        {
            Height = height;
            Width = width;
            CurrentCol = currentCol;
            CurrentCopy = currentCol;
        }


        public void DrawHangman()
        {
            CurrentCol = CurrentCopy;


            int aboutHalf = (Console.BufferWidth / 2) - 5;

            
            for (int i = 0; i < Width; i++)//Draw top
            {
                Console.SetCursorPosition(aboutHalf, CurrentCol);
                Console.Write("=");
                aboutHalf++;
            }

            
            CurrentCol++;//Next Column

            Console.WriteLine("X");//The ting that hold the rope

            //Draw Rope
            for (int i = 0; i < Height / 3; i++)
            {
                
                Console.SetCursorPosition(aboutHalf, CurrentCol + i);//Move the column by one each itteration
                Console.WriteLine("|");

                ColHead = CurrentCol + i; //Saving data for when drawing the man --
                HorHead = aboutHalf;      // -- Since rope lenght is dynamic its good idea to store those values
            }


            aboutHalf = (Console.BufferWidth / 2) -
                        5; //Reseting the Horizontal variabel, probably could do it a diffrent or better way.


            CurrentCol = CurrentCopy + 1; // start point + 1 To start drawing the beam holding the whole thing.

            for (int i = 0; i < Height; i++) //Draw the beam
            {
                Console.SetCursorPosition(aboutHalf, CurrentCol);
                Console.WriteLine("H");

                CurrentCol++; //using ++ here instead of on the setCoursor method because i need the positon to be saved to draw the base.
            }

            // drawing the base
            for (int i = 0; i < Width + 2; i++)
            {
                //                                    H               H
                //                                    H               H
                // -2 cuz it looks better like this ======= than that ========
                Console.SetCursorPosition((aboutHalf + i) - 2, CurrentCol);
                Console.WriteLine("=");
            }

            
            CurrentAfter = CurrentCol;//Saving just in case
        }

        public int ReturnCurrentCol()
        {
            return CurrentAfter;
        }

        public int ReturnColForHead()
        {
            return ColHead;
        }

        public int ReturnHorForHead()
        {
            return HorHead;
        }
    }
}