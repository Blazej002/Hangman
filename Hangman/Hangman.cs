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
                Console.SetCursorPosition(aboutHalf + i, CurrentCol);
                Console.Write("=");
            }   

            aboutHalf = (Console.BufferWidth / 2) - 5; //Reseting the Horizontal variabel, probably could do it a diffrent or better way.

            CurrentCol = CurrentCopy + 1; // start point + 1 To start drawing the beam holding the whole thing.

            for (int i = 0; i < Height; i++) //Draw the beam
            {
                Console.SetCursorPosition(aboutHalf, CurrentCol);
                Console.Write("H");

                //though i could just add the current col + height
                if (i < 3)
                {
                    Console.SetCursorPosition(aboutHalf + Width -1, CurrentCol);
                    Console.WriteLine("|");
                    ColHead = CurrentCol + 1 ;        //Saving data for when drawing the man --
                    HorHead = aboutHalf + Width - 1; // -- Since rope lenght is dynamic its good idea to store those values
                }
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

