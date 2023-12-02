using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Man
    {
        public int wrongs { get; private set; }

        public Man(int x)
        {
            wrongs = x;
        }

        public void CheckHowMany(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart,VerStart);
            if (wrongs >= 1) DrawHead(VerStart, HorStart);
            if (wrongs >= 2) DrawThorso(VerStart, HorStart);
            if (wrongs >= 3) DrawLeftArm(VerStart, HorStart);
            if (wrongs >= 4) DrawRightArm(VerStart, HorStart);
            if (wrongs >= 5) DrawRightLeg(VerStart, HorStart);
            if (wrongs == 6)
            {
                DrawLeftLeg(VerStart, HorStart);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private void DrawHead(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart, VerStart);
            Console.WriteLine("O");
        }

        private void DrawThorso(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart, VerStart + 1);
            Console.Write("|");
        }

        private void DrawRightArm(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart + 1, VerStart + 1);
            Console.WriteLine("\\");
        }

        private void DrawLeftArm(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart - 1, VerStart + 1);
            Console.WriteLine("/");
        }


        private void DrawRightLeg(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart + 1, VerStart + 2);
            Console.WriteLine("\\");
        }

        private void DrawLeftLeg(int VerStart, int HorStart)
        {
            Console.SetCursorPosition(HorStart - 1, VerStart + 2);
            Console.WriteLine("/");
        }


        public void WrongAnswer()
        {
            wrongs++;
        }
    }
}