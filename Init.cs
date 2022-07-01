using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class Init // 초기화 클래스
    {
        public static void InitWindow()
        {
            Console.ResetColor();
            int width = 120; int height = 46; // 윈도우 창 사이즈 설정
            Console.Title = "Console Shooting"; // 제목 설정
            Console.SetWindowSize(width, height); // 창 크기 설정
            Console.BackgroundColor = ConsoleColor.DarkCyan; // 배경 색 설정(흰색)
            Console.Clear(); // 클리어
            Console.CursorVisible = false;
        }
        public static void InitLobby()
        {
            int width = 60; int height = 40; // 윈도우 창 사이즈 설정
            Console.Title = "Console Shooting"; // 제목 설정
            Console.SetWindowSize(width, height); // 창 크기 설정
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray; // 배경 색 설정(흰색)
            Console.Clear(); // 클리어
            Console.CursorVisible = false; // 커서 숨김
        }
        public static bool Start()
        {
            bool isStart = false;
            Console.Clear();
            LineSpace(); // 줄바꿈 7줄
            LineSpace();
            Console.WriteLine("===========================================================");
            Console.WriteLine();
            Console.Write("\t\t   ");
            Console.WriteLine("Shooting Airplane");
            Console.WriteLine();
            Console.WriteLine("===========================================================");
            LineSpace();
            LineSpace();
            Console.Write("\t\t   ");
            Console.WriteLine("Press 'S' To Start");
            Console.WriteLine();
            Console.Write("\t\t    ");
            Console.WriteLine("Press ESC To Quit");

            ConsoleKeyInfo input;
            input = Console.ReadKey();

            if (input.Key == ConsoleKey.S) // S 입력 시 시작
            {
                isStart = true;
            }
            else if (input.Key == ConsoleKey.Escape) // ESC 종료
            {
                Environment.Exit(0);
            }
            return isStart;
        }
        public static void EndGame()
        {
            InitLobby(); // 다시 로비 사이즈 윈도우로
            LineSpace();
            LineSpace();
            Console.WriteLine("===========================================================");
            Console.WriteLine();
            Console.Write("\t\t       ");
            Console.WriteLine("Game Over");
            Console.WriteLine();
            Console.Write("\t\t     ");
            Console.WriteLine("Your Score : " + Frame.score);
            Console.WriteLine("===========================================================");
            LineSpace();
            LineSpace();
            Console.Write("\t\t   ");
            Console.WriteLine("Press 'S' To ReStart");
            Console.WriteLine();
            Console.Write("\t\t    ");
            Console.WriteLine("Press ESC To Quit");

            ConsoleKeyInfo input;
            input = Console.ReadKey();

            if (input.Key == ConsoleKey.S)
            {
                InitWindow();
                ScoreLife.lifeCount = 3;
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
        static void LineSpace() // 줄바꿈 7줄
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
