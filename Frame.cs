using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class Frame : Position // 프레임 갱신 클래스
    {
        // Size
        public static int row = 45; // 표시할 행과 열의 수
        public static int column = 60;
        // Pixel
        public static char[,] pixel = new char[row, column]; // 표시할 픽셀 2차원 배열

        // Game Info
        public static bool isSkill = false;
        public static bool isAttack = false; // 발사 중인지 체크
        //public static bool finishDraw = false;

        public static void DrawFrame(bool isAttack) // 프레임 갱신
        {
            Move.MoveEnemy(); // 적 이동

            Move.CheckMap(); // 맵 끝 체크

            //Skill.MoveSkill();
            Bullet.MoveEnemyBullet(); // 적 총알 이동
            Bullet.MoveBullet(); //  내 총알 이동

            // 2차원 배열 순회
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == 0 && j >= 0 && j < 60)
                    {
                        pixel[i, j] = '■'; // 천장
                    }
                    else if (i == 43 && j >= 0 && j < 60)
                    {
                        pixel[i, j] = '■'; // 바닥
                    }
                    /*
                    else if(i == skillPos_Top[0] && j == skillPos_Top[1])
                    {
                        pixel[i, j] = '★';
                    }
                    else if(i < skillPos_Top[0] && i >= skillPos_Lpoint[0])
                    {
                        if(j >= skillPos_Lpoint[1] && j <= skillPos_Rpoint[1])
                        {
                            pixel[i, j] = '★';
                        }
                    }
                    */
                    else if ((i == bulletPos_L[0] && j == bulletPos_L[1] && isAttack == true)
                        || (i == bulletPos_R[0] && j == bulletPos_R[1] && isAttack == true)
                        || (i == bulletPos[0] && j == bulletPos[1] && isAttack == true))// 총알 위치라면
                    {
                        pixel[i, j] = '♠'; // 총알 그림 대입
                    }
                    else if (i == enemyBulletPos[0] && j == enemyBulletPos[1])
                    {
                        pixel[i, j] = '◆'; // 적 총알
                    }
                    // 적의 포지션이라면
                    else if (i == enemyPos[0] && j == enemyPos[1])
                    {
                        pixel[i, j] = '▼'; // 적 캐릭터 저장
                    }
                    else if ((i == playerPos[0] && j == playerPos[1]) || // 플레이어 라면
                        (i == playerTailPos[0] && j == playerTailPos[1]))
                    {
                        pixel[i, j] = '▲'; // 플레이어 저장
                    }
                    else if((i == playerBodyPos[0] && j == playerBodyPos[1]) ||
                        (i == playerBody2Pos[0] && j == playerBody2Pos[1]) ||
                        (i == playerWingPos_L[0] && j == playerWingPos_L[1]) ||
                        (i == playerWingPos_R[0] && j == playerWingPos_R[1]))
                    {
                        pixel[i, j] = '■'; // 플레이어 저장
                    }
                    else // 아무것도 아니면
                    {
                        pixel[i, j] = '　'; // 공백
                    }
                }
            }
            
            ScoreLife.CheckScoreLife();
            Console.ResetColor(); // 색상 초기화
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            // 다시 배열 순회
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if ((i == bulletPos_L[0] && j == bulletPos_L[1] && isAttack == true) ||
                        (i == bulletPos_R[0] && j == bulletPos_R[1] && isAttack == true))// 총알 위치라면
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(pixel[i, j]);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }/*
                    else if (pixel[i, j] == '★')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(pixel[i, j]);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }*/
                    else if (i == enemyBulletPos[0] && j == enemyBulletPos[1])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(pixel[i, j]);
                        Console.ResetColor(); // 색상 초기화
                        Console.BackgroundColor = ConsoleColor.DarkCyan; // 배경 흰색 초기화
                    }
                    else if ((i == playerPos[0] && j == playerPos[1]) ||
                            (i == playerBodyPos[0] && j == playerBodyPos[1]) ||
                        (i == playerBody2Pos[0] && j == playerBody2Pos[1]) ||
                        (i == playerWingPos_L[0] && j == playerWingPos_L[1]) ||
                        (i == playerWingPos_R[0] && j == playerWingPos_R[1]) ||
                        (i == playerTailPos[0] && j == playerTailPos[1])) // 배열의 원소가 플레이어 라면
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(pixel[i, j]); // 플레이어 원소를 그린다.
                        Console.ResetColor(); // 색상 초기화
                        Console.BackgroundColor = ConsoleColor.DarkCyan; // 배경 흰색 초기화
                    }
                    else if (i == enemyPos[0] && j == enemyPos[1]) // 배열의 원소가 적이라면
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // 빨간색
                        Console.Write(pixel[i, j]);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.Write(pixel[i, j]); // 아무것도 아니면 공백 있던거 출력
                    }
                }
                Console.WriteLine(); // 한 행 끝날때마다 개행
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}
