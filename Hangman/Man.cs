namespace Hangman
{
    internal class Man
    {
        public int wrongs { get; private set; }
        public bool Complete { get; private set; }

        public Man(int x = 0)
        {
            wrongs = x;
            Complete = false;
        }

        public void CheckHowMany(int HorStart, int VerStart)
        {


            Console.SetCursorPosition(HorStart, VerStart);
            //Head
            if (wrongs >= 1) DrawHead(HorStart, VerStart);
            //Thorso
            if (wrongs >= 2) DrawThorso(HorStart, VerStart);
            //Left arm
            if (wrongs >= 3) DrawLeftArm(HorStart, VerStart);
            //and so on
            if (wrongs >= 4) DrawRightArm(HorStart, VerStart);

            if (wrongs >= 5) DrawRightLeg(HorStart, VerStart);

            if (wrongs == 6)
            {
                DrawLeftLeg(HorStart, VerStart);
                Complete = true;
            }
        }

        //   O             H0,V0 
        //  /|\   H-1,V+1  H0,V+1  H+1,V+1
        //  / \   H-1,V+2          H+1,V+2   

        private void DrawHead(int HorStart, int VerStart)
        {
            Console.SetCursorPosition(HorStart, VerStart);
            Console.WriteLine("O");
        }

        private void DrawThorso(int HorStart, int VerStart)
        {
            Console.SetCursorPosition(HorStart, VerStart + 1);
            Console.Write("|");
        }

        private void DrawRightArm(int HorStart, int VerStart)
        {
            Console.SetCursorPosition(HorStart + 1, VerStart + 1);
            Console.WriteLine("\\");
        }

        private void DrawLeftArm(int HorStart, int VerStart)
        {
            Console.SetCursorPosition(HorStart - 1, VerStart + 1);
            Console.WriteLine("/");
        }


        private void DrawRightLeg(int HorStart, int VerStart)
        {
            Console.SetCursorPosition(HorStart + 1, VerStart + 2);
            Console.WriteLine("\\");
        }

        private void DrawLeftLeg(int HorStart, int VerStart)
        {
            Console.SetCursorPosition(HorStart - 1, VerStart + 2);
            Console.WriteLine("/");
        }


        public void WrongAnswer()
        {
            wrongs++;
        }

        public int HowManyWrong()
        {
            return wrongs;
        }

        public bool IsItComplete()
        {
            return Complete;
        }
    }
}