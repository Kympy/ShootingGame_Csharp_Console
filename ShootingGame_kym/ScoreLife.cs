using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class ScoreLife : Frame
    {
        public static int lifeCount = 3; // 목숨 갯수
        public static int score = 0; // 점수 저장 변수
        public static void CheckScoreLife() // 점수와 목숨 체크
        {
            Console.ForegroundColor = ConsoleColor.Black;
            if (score == 0) // 0 점이면 000 표시
            {
                Console.Write("Score : " + "000");
            }
            else
            {
                Console.Write("Score : " + score);
            }
            Console.Write("      ");
            Console.Write("LIFE : ");
            Console.ForegroundColor = ConsoleColor.Red;
            switch(lifeCount) // 목숨 갯수 별 출력
            {
                case 1:
                    {
                        Console.Write("    ♥");
                        break;
                    }
                case 2:
                    {
                        Console.Write("  ♥♥");
                        break;
                    }
                case 3:
                    {
                        Console.Write("♥♥♥");
                        break;
                    }
                case 0:
                    {
                        Console.Write("      ");
                        break;
                    }
            }
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();


        }
    }
}
