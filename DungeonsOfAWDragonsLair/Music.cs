using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Music
    {
        public Music()
        {
            
        }

        #region Noter
        // Noter C4-B5
        int C4 = 262;
        int Cs4 = 278;
        int D4 = 294;
        int Ds4 = 312;
        int E4 = 330;
        int F4 = 350;
        int Fs4 = 370;
        int G4 = 392;
        int Gs4 = 416;
        int A4 = 440;
        int As4 = 466;
        int B4 = 494;
        int C5 = 524;
        int Cs5 = 556;
        int D5 = 588;
        int Ds5 = 624;
        int E5 = 660;
        int F5 = 700;
        int Fs5 = 740;
        int G5 = 784;
        int Gs5 = 832;
        int A5 = 880;
        int As5 = 932;
        int B5 = 988;

        int oct = 2;
        #endregion

        #region BPM
        // 90 bpm
        int WholeNote90 = 2667;
        int HalfNote90 = 1333;
        int QuarterNote90 = 667;
        int EigthNote90 = 333;
        int SixteenthNote90 = 167;
        int ThirtySecondNote90 = 83;

        // 140 bpm
        int WholeNote140 = 1714;
        int HalfNote140 = 857;
        int QuarterNote140 = 429;
        int EigthNote140 = 214;
        int SixteenthNote140 = 107;
        int ThirtySecondNote140 = 54;
        #endregion

        public void IntroMusic()
        {
            Console.Beep(C4, WholeNote140); // 1
            Console.Beep(G4, WholeNote140); // 1
            Console.Beep(C5, WholeNote140); // 1
            Thread.Sleep(EigthNote140);
            Console.Beep(Ds5, QuarterNote140); // 1
            Console.Beep(B4, WholeNote140); // 1

            Console.Beep(C4, EigthNote140); // 1
            Thread.Sleep(EigthNote140);
            Console.Beep(C4, EigthNote140); // 1
            Thread.Sleep(EigthNote140);
            Console.Beep(C4, EigthNote140); // 1
            Console.Beep(D4, EigthNote140); // 1
            Thread.Sleep(EigthNote140);
            Console.Beep(D4, EigthNote140); // 1
            Thread.Sleep(EigthNote140);
            Console.Beep(D4, EigthNote140); // 1
            Console.Beep(G4, WholeNote140); // 1
            Console.Beep(C4, WholeNote140); // 1
        }

        public void AdventureMusic()
        {
            while (true)
            {
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(C4, QuarterNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(D4, QuarterNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(E4, QuarterNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(D4, QuarterNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(C4, QuarterNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(D4, QuarterNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(E4, EigthNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(F4, EigthNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(G4, EigthNote90); };
                if (Game.CurrentAction != 1) { break; } else { Console.Beep(D4, EigthNote90); };
            }
        }

        public void BattleMusic()
        {                    
            Console.Beep(A4/2, EigthNote140); // 1
            Console.Beep(A4, EigthNote140); // 1
            Console.Beep(A4/2, EigthNote140); // 1
            Console.Beep(C4, SixteenthNote140); // 1
            Console.Beep(Cs4, SixteenthNote140); // 1
            Console.Beep(A4, EigthNote140); // 1    

            Console.Beep(A5 / 2, EigthNote140); // 1
            Console.Beep(A5, EigthNote140); // 1
            Console.Beep(A5 / 2, EigthNote140); // 1
            Console.Beep(C5, SixteenthNote140); // 1
            Console.Beep(Cs5, SixteenthNote140); // 1
            Console.Beep(A5, EigthNote140); // 1                    
        }

        public void WinFight()
        {
            Console.Beep(C4, SixteenthNote140); // 1
            Console.Beep(D4, SixteenthNote140); // 1
            Console.Beep(E4, SixteenthNote140); // 1
            Console.Beep(F4, SixteenthNote140); // 1
            Console.Beep(G4, SixteenthNote140); // 1
            Console.Beep(A4, SixteenthNote140); // 1
            Console.Beep(B4, SixteenthNote140); // 1
            Console.Beep(C5, SixteenthNote140); // 1
            Console.Beep(D5, SixteenthNote140); // 1
            Console.Beep(E5, SixteenthNote140); // 1
            Console.Beep(F5, SixteenthNote140); // 1
            Console.Beep(G5, SixteenthNote140); // 1
            Console.Beep(A5, SixteenthNote140); // 1
            Console.Beep(B5, SixteenthNote140); // 1
            Console.Beep(C5 * 2, SixteenthNote140); // 1
        }

        public void PickUpItemSFX()
        {
            Console.Beep(G5, SixteenthNote140); // 1
            Console.Beep(A5, SixteenthNote140); // 1
        }

        public void CantPickUpItemSFX()
        {
            Console.Beep(E4, HalfNote140); // 1
            Console.Beep(Ds4/2, QuarterNote140); // 1
        }

        public void GameOverMusic()
        {
            Console.Beep(C5, HalfNote140);
            Console.Beep(D5, HalfNote140);
            Console.Beep(E5, HalfNote140);
            Console.Beep(G5, QuarterNote140);
            Console.Beep(E5, QuarterNote140);
            Console.Beep(D5, HalfNote140);
            Console.Beep(C5, QuarterNote140);
            Console.Beep(D5, QuarterNote140);
            Console.Beep(C5, HalfNote140);
        }
    }
}
