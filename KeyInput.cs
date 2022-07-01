using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_kym
{
    internal class KeyInput : Frame // 키보드 입력 감지
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int myKey);
        public static void CheckKey()
        {
            short myKey = 0;
            if (Console.KeyAvailable == true) // 키입력이 존재한다면
            {
                myKey = GetAsyncKeyState((int)ConsoleKey.Spacebar); // 공격
                if ((myKey & 0x8000) == 0x8000)
                {
                    isAttack = true;
                }
                else isAttack = false;
                myKey = GetAsyncKeyState((int)ConsoleKey.RightArrow);
                if ((myKey & 0x8000) == 0x8000) // 우측 이동
                {
                    Move.MovePlayerRight();
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.LeftArrow);
                if ((myKey & 0x8000) == 0x8000) // 좌측 이동
                {
                    Move.MovePlayerLeft();
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.D);
                if((myKey & 0x8000) == 0x8000)
                {
                    if(isSkill == true)
                    {
                        return;
                    }
                    else
                    {
                        isSkill = true;
                    }
                }
            }
        }
        public static void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }
    }
}
